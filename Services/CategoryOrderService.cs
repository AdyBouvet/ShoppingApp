using ShopApp.Converters;
using ShopApp.Models;
using ShopApp.Models.DTO;
using ShopApp.Repositories;
using ShopApp.Utils;

namespace ShopApp.Services
{
    public class CategoryOrderService
    {
        private readonly CategoryOrderConverter _converter;
        private readonly CategoryOrderRepository _repo;

        public CategoryOrderService(CategoryOrderConverter converter, CategoryOrderRepository repo)
        {
            _converter = converter;
            _repo = repo;
        }

        public CategoryOrderDTO? Get(string name) =>
            _converter.Convert(_repo.Get(name));

        public List<CategoryOrderDTO> GetAll() =>
            _converter.Convert(_repo.GetAll());

        public Output Create(CategoryOrderDTO CategoryOrder)
        {
            _repo.Create(_converter.Convert(CategoryOrder));
            return Out.Created("Category order");
        }

        public Output Delete(string name)
        {
            CategoryOrder? co = _repo.Get(name);
            if (co == null) 
                return Out.NotFound(name);
            _repo.Delete(co);
            return Out.Deleted(name);
        }
    }
}
