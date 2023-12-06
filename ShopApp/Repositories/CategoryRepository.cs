using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly CommonDbContext _context;

        public CategoryRepository(CommonDbContext context)
        {
            _context = context;
        }

        public void Create(Category entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public Category? Get(string name) => 
            _context.Category.FirstOrDefault(x => x.Name == name);
        

        public List<Category> GetAll() =>
            _context.Category.ToList();
        

        public void Delete(Category category)
        {
            _context.Category.Remove(category);
            _context.SaveChanges();
        }
    }
}
