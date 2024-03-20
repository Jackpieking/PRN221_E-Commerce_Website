using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PRN221_E_Commerce_Website.Data;
using PRN221_E_Commerce_Website.Data.UnitOfWork;
using PRN221_E_Commerce_Website.Options;
using static System.Formats.Asn1.AsnWriter;

Console.OutputEncoding = Encoding.UTF8;

var builder = WebApplication.CreateBuilder(args: args);

// Add services to the container.
builder.Services.AddLogging(configure: config =>
{
    config.ClearProviders();
    config.AddConsole();
});

builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(service =>
{
    var dbOption = builder
        .Configuration.GetRequiredSection("Database")
        .GetRequiredSection("PRN221_MOCK")
        .Get<DatabaseOption>();

    service
        .UseNpgsql(
            dbOption.ConnectionString,
            option =>
            {
                option
                    .EnableRetryOnFailure(dbOption.EnableRetryOnFailure)
                    .CommandTimeout(dbOption.CommandTimeOut);
            }
        )
        .EnableSensitiveDataLogging(dbOption.EnableSensitiveDataLogging)
        .EnableDetailedErrors(dbOption.EnableDetailedErrors)
        .EnableServiceProviderCaching(dbOption.EnableServiceProviderCaching)
        .EnableThreadSafetyChecks(dbOption.EnableThreadSafetyChecks);
    
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder
    .Services.AddAuthentication("LoginUserName")
    .AddCookie(
        "LoginUserName",
        options =>
        {
            options.LoginPath = "/Auth/Login";
            options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        }
    );
var app = builder.Build();

var scope = app.Services.CreateAsyncScope();
var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

var seedResult = await DataSeeding.SeedingAsync(unitOfWork);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(errorHandlingPath: "/Error");
    app.UseHsts();
}

app.UseHttpsRedirection().UseStaticFiles().UseRouting();

app.MapRazorPages();

app.Run();
