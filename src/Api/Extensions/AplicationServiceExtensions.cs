using Application.Common.Mappings;
using Application.Interfaces.Repositories;
using Application.Services;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Api.Extensions;

public static class AplicationServiceExtensions
{

    public static IServiceCollection AddAplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<MongoDbContext>();
        services.AddScoped<IOwnerRepository, OwnerRepository>();
        services.AddScoped<IPropertyRepository, PropertyRepository>();
        services.AddScoped<IImageService, ImageService>();
        return services;
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingOwnerProfile));
        services.AddAutoMapper(typeof(MappingPropertyProfile));
        return services;
    }

}
