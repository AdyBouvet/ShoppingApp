using ShopApp.Models;
using ShopApp.Models.DTO;
using ShopApp.Repositories;

namespace ShopApp.Converters
{
    public class ItemConverter
    {
        private readonly CategoryRepository _repo;

        public ItemConverter(CategoryRepository repo)
        {
            _repo = repo;
        }

        public List<ItemDTO?> Convert(List<Item> items) =>
            items.Select(item => Convert(item)).ToList();

        public List<Item> Convert(List<ItemDTO> items) =>
            items.Select(item => Convert(item)).ToList();

        public Item Convert(ItemDTO item) =>
            new()
            {
                Id = Guid.NewGuid(),
                Name = item.Name,
                Description = item.Description,
                Category = _repo.Get(item.Category)
            };
        

        public ItemDTO? Convert(Item item) => 
            new()
            {
                Category = item.Category == null ? "" : item.Category.Name,
                Description = item.Description,
                Name = item.Name,
            };

        public List<ListItemDTO> Convert(List<ItemShoppingList> list) =>
            list.Select(x => Convert(x)).ToList();

        public ListItemDTO Convert(ItemShoppingList list)
        {
            ItemDTO item = Convert(list.Item);
            return new()
            {
                Amount = list.Amount,
                Comment = list.Comment,
                Category = item.Category,
                Description = item.Description,
                Name = item.Name,
                Bought = list.Bought
            };
        }   
}
}
