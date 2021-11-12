using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public ushort Price { get; set; }
        public bool Volume { get; set; }
        public bool IsFavourite { get; set; }
        public int FastFoodCafeId { get; set; }
        public FastFoodCafe FastFoodCafe { get; set; }
    }
}
