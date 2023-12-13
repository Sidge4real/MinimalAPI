using AutoMapper;
using CourseManager;
using CourseManager.Models;
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


var connection = builder.Configuration["ConnectionStrings:CourseManagerDBConnectionString"];

builder.Services.AddDbContext<CourseManagerDbContext>(o => o.UseMySql(
    connection, ServerVersion.AutoDetect(connection)));

var app = builder.Build();

app.UseHttpsRedirection();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

var coursesEndpoints = app.MapGroup("/courses");
coursesEndpoints.MapGet("", Ok<IEnumerable<CourseDto>> (CourseManagerDbContext courseManagerDbContext,
     ClaimsPrincipal claimsPrincipal,
     IMapper mapper,
     ILogger<CourseDto> logger,
     string? name) =>
{
    //throw new NotImplementedException("This is a test error");
    logger.LogInformation("Getting the dishes");
    Console.WriteLine(claimsPrincipal.Identity?.IsAuthenticated);
    return TypedResults.Ok(mapper.Map<IEnumerable<CourseDto>>(
    courseManagerDbContext.Courses.Where(x => name == null || x.Name.Contains(name))));
});

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<CourseManagerDbContext>();
    context.Database.EnsureDeleted();
    context.Database.Migrate();
}

app.Run();
