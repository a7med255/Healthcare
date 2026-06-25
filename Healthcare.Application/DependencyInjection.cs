using Healthcare.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Healthcare.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile).Assembly);
        return services;
    }
}
