using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories
{
    public class ItemShoppingListRepository : IRepository<ItemShoppingList>
    {

        private readonly CommonDbContext _context;

        public ItemShoppingListRepository(CommonDbContext context)
        {
            _context = context;
        }

        public void Create(ItemShoppingList entity)
        {
            _context.ItemShoppingList.Add(entity);
        }

        public void Delete(ItemShoppingList entity)
        {
            _context.ItemShoppingList.Remove(entity);
            _context.SaveChanges();
        }

        public ItemShoppingList? Get(string name)
        {
            throw new NotImplementedException();
        }

        public ItemShoppingList? Get(Item item, ShoppingList list) => 
            _context.ItemShoppingList
                .FirstOrDefault(x => x.Item == item && x.ShoppingList == list);
        
        public List<ItemShoppingList> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
