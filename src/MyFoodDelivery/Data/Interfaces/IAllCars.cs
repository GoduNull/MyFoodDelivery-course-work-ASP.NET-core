using MyFoodDelivery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.Data.Interfaces
{
    interface IAllCars
    {
        IEnumerable<Car> Cars { get;}
        IEnumerable<Car> GetFavCars { get; set; }
        Car GetObjectCar(int id);

    }
}
