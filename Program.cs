using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using News.Domain;

var builder = WebApplication.CreateBuilder(args);

string articlesConnection = builder.Configuration.GetConnectionString("ArticlesConnection");
string registrationConnection = builder.Configuration.GetConnectionString("RegistrationConnection");

builder.Services.AddDbContext<ArticlesDbContext>(options =>
    options.UseSqlServer(articlesConnection));

// Для RegistrationDbContext
builder.Services.AddDbContext<RegistrationDbContext>(options =>
    options.UseSqlServer(registrationConnection));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<RegistrationDbContext>()
    .AddDefaultTokenProviders();

// Добавляем сервисы авторизации (исправление ошибки)
builder.Services.AddAuthorization();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ArticlesRepository>();

var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
