using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using TestingVGLTU.Infrastructure;
using TestingVGLTU.Accounts.Application;
using TestingVGLTU.LayoutTestings.Application;
using TestingVGLTU.Accounts.Domain.Entity;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Debug()
    .WriteTo.Seq(builder.Configuration.GetConnectionString("Seq")
                 ?? throw new ArgumentException("Seq"))
    .Enrich.WithThreadId()
    .Enrich.WithEnvironmentName()
    .Enrich.WithMachineName()
    .Enrich.WithEnvironmentUserName()
    .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
    .CreateLogger();

builder.Services.AddSerilog();

builder.Services.AddAccountsApplication();

builder.Services.AddLayoutTestingApplication();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(config =>
{
    config.LoginPath = "/Authorization/Login";
    config.AccessDeniedPath = "/Authorization/Login";
    
});

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy(nameof(Student), policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, nameof(Student));
    });
    option.AddPolicy(nameof(Teacher), policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, nameof(Teacher));
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
