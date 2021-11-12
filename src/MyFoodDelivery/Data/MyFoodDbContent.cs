using Microsoft.EntityFrameworkCore;
using MyFoodDelivery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.Data
{
    public class MyFoodDbContent:DbContext
    {
        public MyFoodDbContent(DbContextOptions<MyFoodDbContent> options) 
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<FastFoodCafe> FastFoodCafes { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
