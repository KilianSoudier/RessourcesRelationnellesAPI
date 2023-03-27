using Microsoft.Extensions.Options;
using RessourcesRelationnellesAPI.Models;
using RessourcesRelationnellesAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddJsonFile("appsettings.json",false,false))
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer("Server=localhost;Database=RessourcesRelationnelles;TrustServerCertificate=True;Encrypt=False;persist security info=True;Trusted_Connection=True;"));
var app = builder.Build();
//builder.Services.AddDbContext<DataContext>(options =>
//{
//option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

//});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
//app.MapUtilisateursEndpoints();

app.Run();
