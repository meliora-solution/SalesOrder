using Microsoft.EntityFrameworkCore;
using Microsoft.Fast.Components.FluentUI;
using Server.Data;
using Server.DataLayer.Context;
using ServiceLayer.Dapper.Extentions;


//using ServiceLayer.Dapper.Extentions;
//using CustomerDapper = ServiceLayer.Dapper.CustomerService.Concrete;
//using CustomerEF = ServiceLayer.EF.CustomerService.Concrete;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<soContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddFluentUIComponents();

// Register Services
// builder.Services.AddEFService();

builder.Services.AddDapperService();


var app = builder.Build();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
