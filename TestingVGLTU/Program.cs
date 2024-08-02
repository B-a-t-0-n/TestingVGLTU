using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
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
builder.Services.AddTransient<IGroupRepository, GroupRepository>();
builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<IUserServices, UserServices>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(config =>
{
    config.LoginPath = "/Authorization/Login";
    config.AccessDeniedPath = "/Authorization/Login";
    
});

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("Student", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, "Student");
    });
    option.AddPolicy("Teacher", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, "Teacher");
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authorization}/{action=Login}/{id?}");

app.Run();
