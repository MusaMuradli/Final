using Essence.Business.AutoMappers;
using Essence.Business.Services.Abstractions;
using Essence.Business.Services.Implementations;
using Essence.Business.UIServices.Abstractions;
using Essence.Business.UIServices.Implementations;
using Essence.Core.Entities;
using Essence.DataAccess.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EduHome.Business.ServiceRegistrations;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        services.AddHttpContextAccessor();
        AddServices(services);
        return services;
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICloudinaryService, CloudinaryService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IHomeService, HomeService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IHomeService, HomeService>();
        services.AddScoped<IProductSizeService, ProductSizeService>();
        services.AddScoped<IBasketService, BasketService>();



    }
}
