using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories
{
    public class ShoppingListRepository : IRepository<ShoppingList>
    {

        private readonly CommonDbContext _context;

        public ShoppingListRepository(CommonDbContext context)
        {
            _context = context;
        }

        public void Create(ShoppingList entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public ShoppingList? Get(string name) =>
            Base().FirstOrDefault(x => x.Name == name);

        public List<ShoppingList> GetAll() =>
            Base().ToList();

        public void Update(ShoppingList shoppingList) 
        {
            _context.ShoppingList.Update(shoppingList);
            _context.SaveChanges();
        }

        public void Delete(ShoppingList list)
        {
            _context.ShoppingList.Remove(list);
            _context.SaveChanges();
        }

        public IQueryable<ShoppingList> Base() =>
            _context.ShoppingList
            .Include(x => x.Item).ThenInclude(y => y.Item).ThenInclude(z => z.Category);
    }
}
