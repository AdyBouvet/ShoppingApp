using ShopApp.Models;

namespace ShopApp.Extentions
{
    public static class ItemQuery
    {
        public static IQueryable<Item> Category(this IQueryable<Item> items, string category) =>
            category == null ? items : items.Where(x => x.Category.Name == category);
    }
}
