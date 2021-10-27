using MyFoodDelivery.Data.Interfaces;
using MyFoodDelivery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car
                    {
                        Name="Tesla",
                        ShortDesc = "Быстрый автомобиль",
                        LongDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
                        Img = "https://www.tesla.com/content/dam/tesla-site/sx-redesign/img/socialcard/MS.jpg",
                        Price = 45000,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
            },
                    new Car
                    {
                        Name = "Ford Fiesta",
                        ShortDesc = "Тихий и спокойный",
                        LongDesc = "Удобный автомобиль для городской жизни",
                        Img = "https://www.winnerauto.ua/uploads/gallery_photo/photo/0170/91.jpg",
                        Price = 11000,
                        IsFavourite = false,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        Name = "BMW M3",
                        ShortDesc = "Дерзкий и стильный",
                        LongDesc = "Удобный автомобиль для городской жизни",
                        Img = "https://img.tipcars.com/fotky_velke/33550669_9/2018/E/bmw-m3-top-m-performance-paket.jpg",
                        Price = 65000,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        Name = "Mercedes C class",
                        ShortDesc = "Уютный и большой",
                        LongDesc = "Удобный автомобиль для городской жизни",
                        Img = "https://img.tipcars.com/fotky_velke/33550669_9/2018/E/bmw-m3-top-m-performance-paket.jpg",
                        Price = 40000,
                        IsFavourite = false,
                        Available = false,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        Name = "Nissan Leaf",
                        ShortDesc = "Бесшумный и экономный",
                        LongDesc = "Удобный автомобиль для городской жизни",
                        Img = "https://d2t6ms4cjod3h9.cloudfront.net/wp-content/uploads/2018/11/LEAF_Nissan_Energy_Share-source.jpg",
                        Price = 14000,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
                    }
                };
            }
        }
        public IEnumerable<Car> GetFavCars { get; set; }

        public Car GetObjectCar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
