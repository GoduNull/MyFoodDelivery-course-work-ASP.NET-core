using MyFoodDelivery.Data.Interfaces;
using MyFoodDelivery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.Data.Repository
{
    public class FastFoodCafeRepository : IFastFoodCafe
    {
        private readonly MyFoodDbContent _myFoodDbContent;
        public FastFoodCafeRepository(MyFoodDbContent MyFoodDbContent)
        {
            this._myFoodDbContent = MyFoodDbContent;
        }
        public IEnumerable<FastFoodCafe> AllCategories => _myFoodDbContent.FastFoodCafes;
    }
}
