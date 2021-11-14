using Microsoft.EntityFrameworkCore;
using MyFoodDelivery.Data.Interfaces;
using MyFoodDelivery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.Data.Repository
{
    public class ProductRepository:IAllProduct
    {
        private readonly MyFoodDbContent _myFoodDbContent;
        public ProductRepository(MyFoodDbContent MyFoodDbContent)
        {
            this._myFoodDbContent = MyFoodDbContent;

        }
        public void AddProduct(Product product) //Добавление продукта 
        {
            product.IsFavourite = false;
            _myFoodDbContent.Add(product);
            _myFoodDbContent.SaveChanges();
        }
        public IEnumerable<Product> Products => _myFoodDbContent.Products.Include(c => c.FastFoodCafe);

        public IEnumerable<Product> GetFavCars => _myFoodDbContent.Products.Where(p => p.IsFavourite).Include(c => c.FastFoodCafe);

        public Product GetObjectCar(int carid) => _myFoodDbContent.Products.FirstOrDefault(p => p.Id == carid);

    }
}

