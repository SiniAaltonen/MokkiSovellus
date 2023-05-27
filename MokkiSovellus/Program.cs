using Microsoft.EntityFrameworkCore;
using MokkiSovellus.Models;
using MokkiSovellus.Repositories;
using MokkiSovellus.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MokkiDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MokkiApp")));

builder.Services.AddScoped<IWorkRepository, WorkRepository>();
builder.Services.AddScoped<IWorkService, WorkService>();

builder.Services.AddScoped<ISeasonRepository, SeasonRepository>();
builder.Services.AddScoped<ISeasonService, SeasonService>();

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

app.Run();
