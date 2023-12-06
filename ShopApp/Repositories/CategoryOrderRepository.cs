using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories
{
    public class CategoryOrderRepository : IRepository<CategoryOrder>
    {

        private readonly CommonDbContext _context;

        public CategoryOrderRepository(CommonDbContext context)
        {
            _context = context;
        }

        public void Create(CategoryOrder entity)
        {
            _context.CategoryOrder.Add(entity);
            _context.SaveChanges();
        }

        public List<CategoryOrder> GetAll() => Base().ToList();
        

        public IQueryable<CategoryOrder> Base() => 
            _context.CategoryOrder.Include(x => x.Shop).Include(x => x.Category);
        

        public CategoryOrder? Get(string shopName, string categoryName) =>
            Base()
                .Where(x => x.Category.Name == categoryName)
                .Where(x => x.Shop.Name == shopName)
                .FirstOrDefault();
        

        public void Delete(CategoryOrder co)
        {

            _context.CategoryOrder.Remove(co);
            _context.SaveChanges();
        }

        public CategoryOrder? Get(string name)
        {
            throw new NotImplementedException();
        }
    }
}
