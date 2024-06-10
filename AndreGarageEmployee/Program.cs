using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AndreGarageEmployee.Data;
using AndreGarageAdress.Integration.Interfaces;
using AndreGarageAdress.Integration.Refit;
using AndreGarageAdress.Integration;
using Refit;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AndreGarageEmployeeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AndreGarageEmployeeContext") ?? throw new InvalidOperationException("Connection string 'AndreGarageEmployeeContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAdressIntegration, AdressIntregration>();

builder.Services.AddRefitClient<IAdressRefit>().ConfigureHttpClient(c => c.BaseAddress = new Uri("https://viacep.com.br"));

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
