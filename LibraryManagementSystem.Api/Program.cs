using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Infrastructure.Database;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Infrastructure.Repositories;
using LibraryManagementSystem.Application;
using LibraryManagementSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

// Retrieve the connection string from appsettings.json, throw an error if it's missing
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Register the ApplicationDbContext in the Dependency Injection (DI) container using the SQL Server provider
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// Register Use Cases in the DI container
builder.Services.AddUseCases();

// Register Repositories in the DI container
builder.Services.AddRepositories();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();