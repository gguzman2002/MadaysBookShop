using MadaysBookShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IBookRepository, BookRepository>();

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

DbSeeder.Seed(app);

app.Run();