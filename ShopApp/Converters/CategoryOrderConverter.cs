using ShopApp.Models;
using ShopApp.Models.DTO;
using ShopApp.Repositories;

namespace ShopApp.Converters
{
    public class CategoryOrderConverter
    {
        private readonly CategoryRepository _cRepo;
        private readonly ShopRepository _sRepo;

        public CategoryOrderConverter(CategoryRepository cRepo, ShopRepository sRepo)
        {
            _cRepo = cRepo;
            _sRepo = sRepo;
        }

        public CategoryOrder Convert(CategoryOrderDTO categoryOrder) =>
            new()
            {
                Id = Guid.NewGuid(),
                Order = categoryOrder.Order,
                Category = _cRepo.Get(categoryOrder.Category) ?? new Category(),
                Shop = _sRepo.Get(categoryOrder.Shop) ?? new Shop(),
            };

        public CategoryOrderDTO? Convert(CategoryOrder categoryOrder) =>
            new()
            {
                Order = categoryOrder.Order,
                Category = categoryOrder.Category.Name,
                Shop = categoryOrder.Shop.Name,
            };
        public List<CategoryOrderDTO?> Convert(List<CategoryOrder> categoryOrders) =>
            categoryOrders.Select(x => Convert(x)).ToList();

    }
}
