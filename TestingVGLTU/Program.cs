using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using TestingVGLTU.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

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
