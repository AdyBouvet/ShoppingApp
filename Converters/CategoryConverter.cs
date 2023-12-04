using ShopApp.Models;
using ShopApp.Models.DTO;

namespace ShopApp.Converters
{
    public class CategoryConverter
    {
        public CategoryDTO? Convert(Category category) =>
            new()
            {
                Name = category.Name
            };

        public List<CategoryDTO?> Convert(List<Category> categories) =>
            categories.Select(x => Convert(x)).ToList();

        public Category? Convert(CategoryDTO category) =>
            new()
            {
                Id = Guid.NewGuid(),
                Name = category.Name
            };
    }
}
