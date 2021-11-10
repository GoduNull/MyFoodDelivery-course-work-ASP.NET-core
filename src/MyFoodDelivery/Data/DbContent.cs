﻿using Microsoft.EntityFrameworkCore;
using MyFoodDelivery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MyFoodDelivery.Data
{
    public class DbContent : DbContext
    {
        public DbContent(DbContextOptions<DbContent> options) : base(options)
        {

        }
        public DbSet<Car> Car { get; set; }
        public DbSet<Category> Category {get;set;}
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
