﻿using MyFoodDelivery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.ViewModels
{
    public class ShopCartViewModel
    {
        public ShopCart ShopCart { get; set; }
        public int PriceProduct { get; set; }
        public int PriceAll { get; set; }
    }
}
