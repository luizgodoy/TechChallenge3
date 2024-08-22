using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Prometheus;
using TechChallenge.API.AutoMapper;
using TechChallenge.API.Configurations;
using TechChallenge.Data.Context;
using TechChallenge.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("SqlConnection");

builder.Services.AddDbContext<techchallengeDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(MapperProfile), typeof(MapperProfile));

builder.Services.ResolveDependencies();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddFluentValidation(v =>
{
    v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});


var urls = builder.Configuration.GetSection("AllowOrigins").Get<string[]>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Executa as migrações do banco de dados
app.MigrateDatabase();

app.UseCors(x => x
    .WithOrigins(urls)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

// Configura o endpoint de métricas do Prometheus
app.UseMetricServer();

// Configura a coleta de métricas padrão de ASP.NET Core
app.UseHttpMetrics();

// Garante que o endpoint de métricas está mapeado
app.MapMetrics();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
