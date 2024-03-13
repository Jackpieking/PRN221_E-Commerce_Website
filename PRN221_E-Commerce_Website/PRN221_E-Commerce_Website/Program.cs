using Microsoft.EntityFrameworkCore;
using MockProject.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(
    (service) =>
    {
        service.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
    }
);

var app = builder.Build();

// await using (var scope = app.Services.CreateAsyncScope())
// {
//     var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

//     await context.Database.MigrateAsync();
// }

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
