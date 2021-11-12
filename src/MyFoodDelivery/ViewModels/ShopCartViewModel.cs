using MyFoodDelivery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.ViewModels
{
    public class ShopCartViewModel
    {
        public ShopCart ShopCart { get; set; }
        public double PriceProduct { get; set; }
        public double PriceAll { get; set; }
    }
}
