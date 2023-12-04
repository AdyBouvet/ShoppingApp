﻿using System.ComponentModel.DataAnnotations;

namespace ShopApp.Models
{
    public class Shop
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty; 
        public List<CategoryOrder> CategoryOrders { get; set; } = new();
    }
}
