using BossSpotted.Hubs;
using BossSpotted.Hubs.Interface;
using BossSpotted.Models;
using BossSpotted.Models.Interface;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IBossSpottedHub, BossSpottedHub>();
builder.Services.AddSingleton<IBossSpottedModel, BossSpottedModel>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<BossSpottedHub>("/bossSpottedHub");


app.Run();
