using Microsoft.EntityFrameworkCore;
using SmartSchool.Students.Data;
using SmartSchool.Students.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

await ConfigureDbAsync(app);

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static async Task ConfigureDbAsync(WebApplication app)
{
    var factory = app.Services.GetRequiredService<IDbContextFactory<AppDbContext>>();
    using var context = await factory.CreateDbContextAsync();
    await context.Database.EnsureCreatedAsync();

    if (context.Students.Any())
        return;

    var student = new Student
    {

        RollNumber = "abcdefg1234553",
        FirstName = "Dan",
        LastName = "Patrascu",
        DateOfBirth = new DateTime(2007, 1, 14)
    };
    context.Students.Add(student);
    await context.SaveChangesAsync();
}
