using Microsoft.EntityFrameworkCore;
using MyFoodDelivery.Data.Interfaces;
using MyFoodDelivery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly DbContent dbContent;
        public CarRepository(DbContent dbContent)
        {
            this.dbContent = dbContent;

        }
        public IEnumerable<Car> Cars => dbContent.Car.Include(c=>c.Category);

        public IEnumerable<Car> GetFavCars => dbContent.Car.Where(p=>p.IsFavourite).Include(c => c.Category);

        public Car GetObjectCar(int carid) => dbContent.Car.FirstOrDefault(p => p.Id == carid);
 
    }
}
