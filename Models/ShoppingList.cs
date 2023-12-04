using ShopApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.Models
{
    public class ShoppingList
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ItemShoppingList> Item { get; set; } = new();
        public ShopType Type { get; set; }
    }
}
