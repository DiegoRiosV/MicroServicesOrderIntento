using orderMicroService.Application.Services;
using orderMicroService.Domain.Entities;
using orderMicroService.Domain.Ports;
using orderMicroService.Domain.Services;
using orderMicroService.Infrastructure.Connection;
using orderMicroService.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connection String
var connectionString = builder.Configuration.GetConnectionString("PaymentDB");

// Header Configuration
builder.Services.AddSingleton<DatabaseConnectionManager>(_ => DatabaseConnectionManager.GetInstance(connectionString));
builder.Services.AddScoped<IDbConnectionFactory, PostgreSqlConnection>();

// Repositories
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Services
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<IValidator<Order>, OrderValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapGet("/", () => Results.Redirect("/swagger"));
}
app.UseAuthorization();

app.MapControllers();

app.Run();
