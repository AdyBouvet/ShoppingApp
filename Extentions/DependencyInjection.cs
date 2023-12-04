using ShopApp.Converters;
using ShopApp.Repositories;
using ShopApp.Services;

namespace DispApi.Extentions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAllInjections(this IServiceCollection services)
        {
            services.AddTransient<ItemConverter>();
            services.AddTransient<ItemRepository>();
            services.AddTransient<ItemService>();

            services.AddTransient<ShopConverter>();
            services.AddTransient<ShopRepository>();
            services.AddTransient<ShopService>();

            services.AddTransient<CategoryConverter>();
            services.AddTransient<CategoryRepository>();
            services.AddTransient<CategoryService>();

            services.AddTransient<CategoryOrderConverter>();
            services.AddTransient<CategoryOrderRepository>();
            services.AddTransient<CategoryOrderService>();

            services.AddTransient<ShoppingListConverter>();
            services.AddTransient<ShoppingListRepository>();
            services.AddTransient<ShoppingListService>();

            services.AddTransient<ItemShoppingListRepository>();

            return services;
        }
    }
}
