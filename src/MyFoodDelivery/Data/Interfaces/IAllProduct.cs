using MyFoodDelivery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.Data.Interfaces
{
    public interface IAllProduct
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> GetFavCars { get; }
        Product GetObjectCar(int carid);

    }
}
