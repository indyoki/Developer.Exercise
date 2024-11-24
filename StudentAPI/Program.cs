using Microsoft.EntityFrameworkCore;
using Serilog;
using StudentAPI.Models;
using StudentAPI.Repository;
using StudentAPI.Repository.Interfaces;
using StudentAPI.Services;
using StudentAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddControllers();
builder.Services.AddScoped<IStudentManager, StudentManager>();
builder.Services.AddDbContext<StudentManagementDBContext>(x => {
    x.UseSqlServer(builder.Configuration.GetConnectionString("StudentManagementDB"));
});

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("Logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var app = builder.Build();

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
