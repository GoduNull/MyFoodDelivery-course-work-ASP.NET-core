using MyFoodDelivery.Data.Interfaces;
using MyFoodDelivery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.Data.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category{CategoryName="Электромобили", Desc="Современные"},
                    new Category{CategoryName="Классика", Desc="С двигателем внутреннего згорания"}
                };
            }
            
        }
    }
}
