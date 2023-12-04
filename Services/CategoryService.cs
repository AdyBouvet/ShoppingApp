using ShopApp.Converters;
using ShopApp.Models;
using ShopApp.Models.DTO;
using ShopApp.Repositories;
using ShopApp.Utils;

namespace ShopApp.Services
{
    public class CategoryService
    {
        private readonly CategoryConverter _converter;
        private readonly CategoryRepository _repo;
        private readonly ItemRepository _itemRepo;

        public CategoryService(CategoryConverter converter, CategoryRepository repo, ItemRepository itemRepo)
        {
            _converter = converter;
            _repo = repo;
            _itemRepo = itemRepo;
        }

        public CategoryDTO? Get(string name) =>
            _converter.Convert(_repo.Get(name));

        public List<CategoryDTO?> GetAll() =>
            _converter.Convert(_repo.GetAll());

        public Output Create(CategoryDTO category)
        {
            if(_repo.Get(category.Name) == null)
            {
                _repo.Create(_converter.Convert(category));
                return Out.Created(category.Name);
            }
            return Out.Exists(category.Name);
        }

        public Output Delete(string name)
        {
            Category? category = _repo.Get(name);
            if (category == null) 
                return Out.NotFound(name);

            int itemCount = _itemRepo.GetCategoryCount(name);
            if (itemCount > 0) 
                return Out.CustomError("Can't delete category when it as any items connected to it");
            
            _repo.Delete(category);
            return Out.Deleted(name);
        }
    }
}
