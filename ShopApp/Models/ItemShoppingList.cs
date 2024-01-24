namespace ShopApp.Models
{
    public class ItemShoppingList
    {
        public Guid Id { get; set; }
        public Item Item { get; set; }
        public ShoppingList ShoppingList { get; set; }
        public int Amount { get; set; }
        public string Comment { get; set; } = string.Empty;
        public bool Bought { get; set; } = false;
    }
}
