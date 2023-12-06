using ShopApp.Models;
using ShopApp.Models.DTO;

namespace ShopApp.Converters
{
    public class ShopConverter
    {
        public ShopDTO Convert(Shop shop) =>
            new()
            {
                Name = shop.Name,
                Brand = shop.Brand
            };

        public List<ShopDTO> Convert(List<Shop> shops) =>
            shops.Select(x => Convert(x)).ToList();

        public Shop Convert(ShopDTO shop) =>
            new()
            {
                Id = Guid.NewGuid(),
                Name = shop.Name,
                Brand = shop.Brand
            };
    }
}
