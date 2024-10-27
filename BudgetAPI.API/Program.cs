using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Entity.Entities;
using BudgetAPI.BusinessLayer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlite(@"Data Source=BudgetAPI.db", b => b.MigrationsAssembly("BudgetAPI.API"));
}, ServiceLifetime.Scoped, ServiceLifetime.Scoped);
builder.Services.AddTransient<IService, Service>();
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
