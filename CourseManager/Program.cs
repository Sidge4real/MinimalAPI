using AutoMapper;
using CourseManager;
//using CourseManager.Entities;
//using CourseManager.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddProblemDetails();


var connection = builder.Configuration["CourseManagerDBConnectionString"];

builder.Services.AddDbContext<CourseManagerDbContext>(o => o.UseMySql(
    connection, ServerVersion.AutoDetect(connection)));

var app = builder.Build();

app.UseHttpsRedirection();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

// ...

app.Run();
