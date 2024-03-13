using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PRN221_E_Commerce_Website.Data;
using PRN221_E_Commerce_Website.Options;
using System;
using System.Text;

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
    var dbOption = builder.Configuration
        .GetRequiredSection("Database")
        .GetRequiredSection("PRN221_MOCK")
        .Get<DatabaseOption>();

    service.UseNpgsql(
        dbOption.ConnectionString,
        option =>
        {
            option
                .EnableRetryOnFailure(dbOption.EnableRetryOnFailure)
                .CommandTimeout(dbOption.CommandTimeOut);
        })
    .EnableSensitiveDataLogging(dbOption.EnableSensitiveDataLogging)
    .EnableDetailedErrors(dbOption.EnableDetailedErrors)
    .EnableServiceProviderCaching(dbOption.EnableServiceProviderCaching)
    .EnableThreadSafetyChecks(dbOption.EnableThreadSafetyChecks);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(errorHandlingPath: "/Error");
    app.UseHsts();
}

app
    .UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting();

app.MapRazorPages();

app.Run();
