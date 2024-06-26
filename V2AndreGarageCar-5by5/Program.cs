﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using V2AndreGarageCar_5by5.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<V2AndreGarageCar_5by5Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("V2AndreGarageCar_5by5Context") ?? throw new InvalidOperationException("Connection string 'V2AndreGarageCar_5by5Context' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
