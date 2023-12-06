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

        public CategoryOrderDTO? Get(string shopName, string categoryName) =>
            _converter.Convert(_repo.Get(shopName, categoryName));

        public List<CategoryOrderDTO> GetAll() =>
            _converter.Convert(_repo.GetAll());

        public Output Create(CategoryOrderDTO categoryOrder)
        {
            CategoryOrder? order = _repo.Get(categoryOrder.Shop, categoryOrder.Category);
            if (order == null)
            {
                _repo.Create(_converter.Convert(categoryOrder));
                return Out.Created("Category order");
            }
            return Out.Exists(categoryOrder.Shop + "+" + categoryOrder.Category);
        }

        public Output Delete(string shopName, string categoryName)
        {
            CategoryOrder? co = _repo.Get(shopName, categoryName);
            if (co == null)
                return Out.NotFound(shopName);
            _repo.Delete(co);
            return Out.Deleted(shopName);
        }
    }
}
