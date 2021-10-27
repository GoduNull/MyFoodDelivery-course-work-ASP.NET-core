using MyFoodDelivery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.ViewModels
{
    public class CarsListViewModels
    {
        public IEnumerable<Car> AllCars { get; set; }
        public string CurrCategory { get; set; }
    }
}
