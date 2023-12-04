using Azure.Core;
using Azure.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models;

namespace ShopApp.Data
{
    public class CommonDbContext : DbContext
    {
        public CommonDbContext(DbContextOptions<CommonDbContext> options) : base(options)
        {
            var conn = (SqlConnection)Database.GetDbConnection();
            var tokenCredential = new DefaultAzureCredential();
            conn.AccessToken = tokenCredential.GetToken(
                new TokenRequestContext(new[] { "https://database.windows.net/.default" })).Token;
        }

        public DbSet<Item> Item { get; set; }
        public DbSet<Shop> Shop { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShoppingList> ShoppingList { get; set; }
        public DbSet<CategoryOrder> CategoryOrder { get; set; }
        public DbSet<ItemShoppingList> ItemShoppingList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>()
                .HasMany(s => s.CategoryOrders)
                .WithOne(c => c.Shop);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.CategoryOrders)
                .WithOne(c => c.Category);

            modelBuilder.Entity<ShoppingList>()
                .HasMany(s => s.Item)
                .WithOne(i => i.ShoppingList);
            
            modelBuilder.Entity<Item>()
                .HasMany(i => i.ShoppingList)
                .WithOne(i => i.Item);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Items)
                .WithOne(i => i.Category);
        }
    }
}
