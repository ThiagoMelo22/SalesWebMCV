using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMcv.Data;
using SalesWebMcv.Models;
using SalesWebMcv.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SalesWebMcvContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("SalesWebMcvContext") ?? throw new InvalidOperationException("Connection string 'SalesWebMcvContext' not found."), 
    new MySqlServerVersion(new Version(8, 0, 36)), b =>  b.MigrationsAssembly("SalesWebMcv")
    ));

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else 
{
    using (var scope = app.Services.CreateScope()) 
    {
        var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
        seedingService.Seed();
    }
}

    app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
