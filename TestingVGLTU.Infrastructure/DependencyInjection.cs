using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestingVGLTU.Accounts.Application;
using TestingVGLTU.Accounts.Application.Providers;
using TestingVGLTU.ActiveTestings.Application;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.Core.Providers;
using TestingVGLTU.Infrastructure.DbContexts;
using TestingVGLTU.Infrastructure.Providers;
using TestingVGLTU.Infrastructure.Repositories;
using TestingVGLTU.LayoutTestings.Application;
using TestingVGLTU.SharedKernel;

namespace TestingVGLTU.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .AddDatabase(configuration)
            .AddRepositories()
            .AddProviders();
    }


    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ILayoutTestingRepository, LayoutTestingRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IActiveTestingRepository, ActiveTestingRepository>();

        return services;
    }

    private static IServiceCollection AddProviders(this IServiceCollection services)
    {
        return services
            .AddScoped<IDateTimeProvider, DateTimeProvider>()
            .AddScoped<IPasswordHasherProvider, PasswordHasher>();
    }

    private static IServiceCollection AddDatabase(
       this IServiceCollection services,
       IConfiguration configuration)
    {
        services.AddScoped<IReadLayoutTestingDbContext>(provider => provider.GetRequiredService<TestingDbContext>());
        services.AddScoped<IReadAccountDbContext>(provider => provider.GetRequiredService<TestingDbContext>());
        services.AddScoped<IReadActiveTestingDbContext>(provider => provider.GetRequiredService<TestingDbContext>());

        services.AddScoped<TestingDbContext>(_ =>
            new TestingDbContext(configuration.GetConnectionString(Constants.DATABASE)!));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
