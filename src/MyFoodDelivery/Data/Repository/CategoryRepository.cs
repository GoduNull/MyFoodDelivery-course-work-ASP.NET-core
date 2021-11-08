using MyFoodDelivery.Data.Interfaces;
using MyFoodDelivery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly DbContent dbContent;
        public CategoryRepository(DbContent dbContent)
        {
            this.dbContent = dbContent;

        }
        public IEnumerable<Category> AllCategories => dbContent.Category;
    }
}
