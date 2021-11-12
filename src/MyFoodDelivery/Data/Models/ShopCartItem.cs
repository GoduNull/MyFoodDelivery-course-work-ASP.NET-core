using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.Data.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public double Price { get; set; }
        public string ShopCarId { get; set; }
    }
}
