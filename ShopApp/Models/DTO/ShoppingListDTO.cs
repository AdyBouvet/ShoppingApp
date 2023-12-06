using ShopApp.Enums;

namespace ShopApp.Models.DTO
{
    public class ShoppingListDTO
    {
        public string Name { get; set; } = string.Empty;
        public List<ListItemDTO> Items { get; set; } = new();
        public ShopType Type { get; set; }
    }
}
