using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestingVGLTU.Infrastructure.DbContexts;
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
            .AddRepositories();
    }


    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services;
    }

    private static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped(_ =>
            new TestingDbContext(configuration.GetConnectionString(Constants.DATABASE)!));

        return services;
    }
}
