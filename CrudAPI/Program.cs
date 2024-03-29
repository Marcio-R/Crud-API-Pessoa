﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CrudAPI.Data;
using CrudAPI.Controllers;
using CrudAPI.Sevice;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CrudAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CrudAPIContext") ?? throw new InvalidOperationException("Connection string 'CrudAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<PessoaService>();
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
