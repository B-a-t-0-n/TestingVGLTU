using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Data;
using TestingVGLTU.Data.Repositories;
using TestingVGLTU.Infrastructure;
using TestingVGLTU.Interfaces;
using TestingVGLTU.Interfaces.Repositories;
using TestingVGLTU.Interfaces.Services;
using TestingVGLTU.Services;

var builder = WebApplication.CreateBuilder(args);

// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));

builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<ITeacherRepository, TeacherRepository>();
builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<IUserServices, UserServices>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(config =>
{
    config.LoginPath = "/Auth/Login";
    config.LogoutPath = "/Auth/Login";
    config.AccessDeniedPath = "/Home/Error";
});

builder.Services.AddAuthorization(config =>
{
    config.AddPolicy("User", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
    config.AddPolicy("Admin", policy =>
    {
        policy.RequireClaim("IsAdmin", "True");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authorization}/{action=Login}/{id?}");

app.Run();
