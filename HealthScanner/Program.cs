using DataContext;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();


// שליפת מחרוזת החיבור מקובץ ההגדרות (appsettings.json)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// הזרקת התלות של ה-Context שלך
builder.Services.AddDbContext<HealthScannerContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<Icontext, HealthScannerContext>();
// אחרי AddDbContext
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();      // מפעיל את Swagger JSON
    app.UseSwaggerUI();    // מפעיל את ה־UI
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
