using BossSpotted;
using BossSpotted.Hubs;
using BossSpotted.Hubs.Interface;
using BossSpotted.Models.EntityFramework;
using BossSpotted.Models.Validations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

builder.Configuration.AddJsonFile($"appsettings.json", false);
builder.Configuration.AddJsonFile($"appsettings.{Environment.MachineName}.json", false);

builder.Services.AddOptions();
builder.Services.Configure<BossSpottedOptions>(
    builder.Configuration.GetSection("BossSpottedOptions"));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IBossSpottedHub, BossSpottedHub>();

builder.Services.AddSingleton<BossSpottedContext>();
builder.Services.AddSingleton<InputValidation>();


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
