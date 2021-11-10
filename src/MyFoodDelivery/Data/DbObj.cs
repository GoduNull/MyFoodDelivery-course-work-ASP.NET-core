using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MyFoodDelivery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.Data
{
    public class DbObj
    {
        public static void Initial(DbContent content)
        {
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(content => content.Value));
            }
            if (!content.Car.Any())
            {
                content.AddRange(
                    new Car
                    {
                        Name = "Tesla",
                        ShortDesc = "Быстрый автомобиль",
                        LongDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
                        Img = "/img/tesla.jpg",
                        Price = 45000,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        Name = "Ford Fiesta",
                        ShortDesc = "Тихий и спокойный",
                        LongDesc = "Удобный автомобиль для городской жизни",
                        Img = "/img/fiesta.jpg",
                        Price = 11000,
                        IsFavourite = false,
                        Available = true,
                        Category = Categories["Классика"]
                    },
                    new Car
                    {
                        Name = "BMW M3",
                        ShortDesc = "Дерзкий и стильный",
                        LongDesc = "Удобный автомобиль для городской жизни",
                        Img = "/img/m3.jpg",
                        Price = 65000,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Классика"]
                    },
                    new Car
                    {
                        Name = "Mercedes C class",
                        ShortDesc = "Уютный и большой",
                        LongDesc = "Удобный автомобиль для городской жизни",
                        Img = "/img/mercedes.jpg",
                        Price = 40000,
                        IsFavourite = false,
                        Available = false,
                        Category = Categories["Классика"]
                    },
                    new Car
                    {
                        Name = "Nissan Leaf",
                        ShortDesc = "Бесшумный и экономный",
                        LongDesc = "Удобный автомобиль для городской жизни",
                        Img = "/img/nissan.jpg",
                        Price = 14000,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Классика"]
                    });

            }
            content.SaveChanges();

        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {

                if (category == null)
                {
                    var list = new Category[]
                    {
      new Category{CategoryName="Электромобили", Desc="Современные"},
                    new Category{CategoryName="Классика", Desc="С двигателем внутреннего згорания"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.CategoryName, el);
                }
                return category;
            }
        }
    }
}

