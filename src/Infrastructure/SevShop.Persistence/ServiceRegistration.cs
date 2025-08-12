using Microsoft.Extensions.DependencyInjection;
using SevShop.Application.Abstracts.Repositories;
using SevShop.Application.Abstracts.Services;
using SevShop.Infrastructure.Services;
using SevShop.Persistence.Repositories;
using SevShop.Persistence.Services;

namespace SevShop.Persistence;

public static class ServiceRegistration
{
    public static void RegisterService(this IServiceCollection services)
    {
        #region Repositories
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IFavoriteRepository, FavoriteRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IImageRepository, ImageRepository>();
        #endregion

        #region Services
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IFavoriteService, FavoriteService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IFileUpload, FileUpload>();
        services.AddScoped<IImageService, ImageService>();
        #endregion
    }
}