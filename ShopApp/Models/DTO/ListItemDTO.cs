namespace ShopApp.Models.DTO
{
    public class ListItemDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Amount { get; set; } = 1;
        public string Comment {  get; set; } = string.Empty;
    }
}
