using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Web.Components;
using SmartSchool.Web.Data;
using SmartSchool.Web.Extensions.FrameworkExtensions;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.ConfigureIdentity();

builder.Services.ConfigureAuthentication();

var app = builder.Build();

await ConfigureDbAsync(app);

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();


static async Task ConfigureDbAsync(WebApplication app)
{
    var factory = app.Services.GetRequiredService<IDbContextFactory<AppDbContext>>();
    using var context = await factory.CreateDbContextAsync();
    await context.Database.EnsureCreatedAsync();

    if (context.Users.Any())
        return;

    await CreateUserAndRoleAsync(app);
}

static async Task CreateUserAndRoleAsync(WebApplication app)
{
    var userManager = app.Services.GetRequiredService<UserManager<IdentityUser>>();
    var userStore = app.Services.GetRequiredService<IUserStore<IdentityUser>>();
    var roleManager = app.Services.GetRequiredService<RoleManager<IdentityRole>>();

    var identity = new IdentityUser();

    var email = "user@domain.com";
    var password = "12345";
    var roleName = "Superadmin";
    List<Claim> claims = [new("firstName", "Dan"), new("lastName", "Patrascu")];

    await userManager.SetUserNameAsync(identity, email);
    var emailStore = (IUserEmailStore<IdentityUser>)userStore;
    await emailStore.SetEmailAsync(identity, email, CancellationToken.None);
    await userManager.CreateAsync(identity, password);

    await userManager.AddClaimsAsync(identity, claims);

    var superAdminRole = new IdentityRole(roleName);

    await roleManager.CreateAsync(superAdminRole);
    await userManager.AddToRoleAsync(identity, roleName);
}