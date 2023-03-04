using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultipleTenancyTest.Data;
using MultipleTenancyTest.Model;
using MultipleTenancyTest.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
var connectionString = configuration.GetSection("ConnectionStrings");
builder.Services.AddRazorPages();
builder.Services.Configure<TenantConfig>(configuration.GetSection("ConnectionStrings:TenantConnection"));

builder.Services.AddDbContext<TenantDataBaseContext>(options => options.UseSqlServer(connectionString["DefaultConnection"]));
builder.Services.AddDbContext<TenantContext>();
builder.Services.AddTransient<ITenantService, TenantService>();
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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
