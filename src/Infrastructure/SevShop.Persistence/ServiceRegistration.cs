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
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderProductRepository, OrderProductRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<ISizeRepository, SizeRepository>();
        services.AddScoped<ILanguageRepository, LanguageRepository>();
        services.AddScoped<IGenderRepository, GenderRepository>();
        services.AddScoped<IColorRepository, ColorRepository>();
        services.AddScoped<IChatMessageRepository, ChatMessageRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IBasketItemRepository, BasketItemRepository>();
        services.AddScoped<IBasketRepository, BasketRepository>();
        #endregion

        #region Services
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IFavoriteService, FavoriteService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IFileUpload, FileUpload>();
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderProductService, OrderProductService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<ISizeService, SizeService>();
        services.AddScoped<ILanguageService, LanguageService>();
        services.AddScoped<IGenderService, GenderService>();
        services.AddScoped<IColorService, ColorService>();
        services.AddScoped<IChatMessageService, ChatMessageService>();
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IBasketItemService, BasketItemService>();
        services.AddScoped<IBasketService, BasketService>();
        #endregion
    }
}