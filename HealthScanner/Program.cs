using DataContext;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


// שליפת מחרוזת החיבור מקובץ ההגדרות (appsettings.json)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// הזרקת התלות של ה-Context שלך
builder.Services.AddDbContext<HealthScannerContext>(options =>
    options.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
