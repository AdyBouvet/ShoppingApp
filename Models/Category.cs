using System.ComponentModel.DataAnnotations;

namespace ShopApp.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<CategoryOrder> CategoryOrders { get; set; } = new();
        public List<Item> Items { get; set; } = new();
    }
}
