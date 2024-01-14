using Microsoft.EntityFrameworkCore;
using SmartSchool.Web.Components;
using SmartSchool.Web.Data;
using SmartSchool.Web.Extensions.FrameworkExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.ConfigureIdentity();

builder.Services.ConfigureAuthentication();

var app = builder.Build();

var factory = app.Services.GetRequiredService<IDbContextFactory<AppDbContext>>();
using var context = await factory.CreateDbContextAsync();
await context.Database.EnsureCreatedAsync();

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
