using Microsoft.EntityFrameworkCore;
using Microsoft.Fast.Components.FluentUI;
using Server.DataLayer.Context;
using ServiceLayerEF.Extentions;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<soContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddFluentUIComponents();

// Register Services

builder.Services.AddEFService();


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
