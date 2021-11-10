using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.Data.Models
{
    public class ShopCart
    {
        private readonly DbContent dbContent;
        public ShopCart(DbContent dbContent)
        {
            this.dbContent = dbContent;

        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }
        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<DbContent>();
            string shopCartid = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartid);
            return new ShopCart(context) { ShopCartId = shopCartid };
        }
        public void AddToCart(Car car)
        {
            this.dbContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCarId = ShopCartId,
                Car=car,
                Price = car.Price
            });
            dbContent.SaveChanges();
        }
        public List<ShopCartItem> GetShopCartItems()
        {
            return dbContent.ShopCartItem.Where(c => c.ShopCarId == ShopCartId).Include(s => s.Car).ToList();
        }
    }
}
