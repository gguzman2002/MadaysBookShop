using MadaysBookShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();

builder.Services.AddScoped<IBookRepository, MockBookRepository>();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MadaysBookShopDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:MadaysBookShopDbContextConnection"]);
});

var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();

app.Run();
