using MyFoodDelivery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.Data.Interfaces
{
    public interface IFastFoodCafe
    {
        IEnumerable<FastFoodCafe> AllCategories { get; }
    }
}
