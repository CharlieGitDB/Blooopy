using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Blooopy.Data;
using Microsoft.EntityFrameworkCore;
using Blooopy.Models;
using Blooopy.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContextFactory<BlooopContext>(o =>
{
   o.UseSqlite($"Data Source=${nameof(BlooopContext.Blooops)}.db");
});

builder.Services.AddTransient<BlooopService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    await using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateAsyncScope();
    var options = scope.ServiceProvider.GetRequiredService<DbContextOptions<BlooopContext>>();
    await DatabaseUtility.EnsureDbCreatedAndSeed(options, 15);
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
