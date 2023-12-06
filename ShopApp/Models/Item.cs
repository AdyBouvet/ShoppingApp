using System.ComponentModel.DataAnnotations;

namespace ShopApp.Models
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty; 
        public Category? Category { get; set; }
        public List<ItemShoppingList> ShoppingList { get; set; } = new();
    }
}
