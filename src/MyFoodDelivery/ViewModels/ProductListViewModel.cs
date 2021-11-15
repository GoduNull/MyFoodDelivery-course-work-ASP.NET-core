using MyFoodDelivery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> AllProduct { get; set; }
        public string CurrFastFoodCafe { get; set; }
    }
}
