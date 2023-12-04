using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories
{
    public class ItemRepository : IRepository<Item>
    {
        private readonly CommonDbContext _context;

        public ItemRepository(CommonDbContext context)
        {
            _context = context;
        }

        public void Create(Item entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Item item)
        {
            _context.Item.Remove(item);
            _context.SaveChanges();
        }

        public int GetCategoryCount(string name) =>
            _context.Item.Count(x => x.Category.Name == name);

        public Item? Get(string name) => 
            Base().FirstOrDefault(x => x.Name == name);
        
        public List<Item> GetAll() => Base().ToList();
        public IQueryable<Item> GetAllQuery() => Base();
        
        private IQueryable<Item> Base() => _context.Item.Include(x => x.Category);

    }
}
