﻿using MyFoodDelivery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> FavProduct {get;set;}
    }
}
