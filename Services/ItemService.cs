using ShopApp.Converters;
using ShopApp.Extentions;
using ShopApp.Models;
using ShopApp.Models.DTO;
using ShopApp.Repositories;
using ShopApp.Utils;

namespace ShopApp.Services
{
    public class ItemService
    {
        private readonly ItemConverter _converter;
        private readonly ItemRepository _repo;
        private readonly CategoryRepository _cRepo;

        public ItemService(ItemConverter converter, ItemRepository repo, CategoryRepository cRepo)
        {
            _converter = converter;
            _repo = repo;
            _cRepo = cRepo;
        }

        public ItemDTO? Get(string name) =>
            _converter.Convert(_repo.Get(name));

        public List<ItemDTO> GetAll(string category)
        {
            List<Item> items = _repo.GetAllQuery()
                .Category(category)
                .ToList();

            return _converter.Convert(items);
        }

        public Output Create(ItemDTO item)
        {
            if (_cRepo.Get(item.Category) == null)
                return Out.NotFound(item.Category);

            if (_repo.Get(item.Name) != null)
                return Out.Exists(item.Name);

            _repo.Create(_converter.Convert(item));
            return Out.Created(item.Name);
        }
        public Output Delete(string name)
        {
            Item? item = _repo.Get(name);
            if (item != null)
            {
                _repo.Delete(item);
                return Out.Deleted(name);
            }
            return Out.NotFound(name);
        }
    }
}
