
using ESunBank.Models;
using ESunBank_BLL;
using ESunBank_BLL.Interface;
using ESunBank_DAL;
using ESunBank_DAL.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IWeather_DAL, Weather_DAL>();
builder.Services.AddScoped<IWeather_BLL, Weather_BLL>();
builder.Services.AddDbContext<WeatherContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("WeatherDatabase")));

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
