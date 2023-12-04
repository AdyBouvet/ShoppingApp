using ShopApp.Converters;
using ShopApp.Models;
using ShopApp.Models.DTO;
using ShopApp.Repositories;
using ShopApp.Utils;

namespace ShopApp.Services
{
    public class ShopService
    {
        private readonly ShopRepository _repo;
        private readonly ShopConverter _converter;

        public ShopService(ShopRepository repo, ShopConverter converter)
        {
            _repo = repo;
            _converter = converter;
        }

        public ShopDTO Get(string name) =>
            _converter.Convert(_repo.Get(name));

        public List<ShopDTO> GetAll() =>
            _converter.Convert(_repo.GetAll());

        public Output Create(ShopDTO shop)
        {
            if (_repo.Get(shop.Name) != null)
                return Out.Exists(shop.Name);

            _repo.Create(_converter.Convert(shop));
            return Out.Created(shop.Name);
        }

        public Output Delete(string name)
        {
            Shop? shop = _repo.Get(name);
            if (shop != null)
            {
                _repo.Delete(shop);
                return Out.NotFound(name);
            }
            return Out.Deleted(name);
        }
        

    }
}
