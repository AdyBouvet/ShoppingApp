using System.ComponentModel.DataAnnotations;

namespace ShopApp.Models
{
    public class CategoryOrder
    {
        [Key]
        public Guid Id { get; set; }

        public Category? Category { get; set; }
        public Shop? Shop { get; set; }
        public int Order { get; set; }
    }
}
