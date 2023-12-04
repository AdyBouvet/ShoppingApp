using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories
{
    public class ShopRepository : IRepository<Shop>
    {
        private readonly CommonDbContext _context;

        public ShopRepository(CommonDbContext context)
        {
            _context = context;
        }

        public void Create(Shop entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Shop shop)
        {
            _context.Shop.Remove(shop);
            _context.SaveChanges();
        }

        public Shop? Get(string name) => 
            _context.Shop.FirstOrDefault(x => x.Name == name);
        

        public List<Shop> GetAll() => 
            _context.Shop.ToList();
        
    }
}
