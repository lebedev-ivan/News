using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using News.Domain;

var builder = WebApplication.CreateBuilder(args);

// Добавляем DbContext и строку подключения
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавляем сервисы авторизации (исправление ошибки)
builder.Services.AddAuthorization();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ArticlesRepository>();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
