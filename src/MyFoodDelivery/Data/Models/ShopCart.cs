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
        private readonly MyFoodDbContent _myFoodDbContent;
        public ShopCart(MyFoodDbContent myFoodDbContent)
        {
            this._myFoodDbContent = myFoodDbContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }
        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<MyFoodDbContent>();
            string shopCartid = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartid);
            return new ShopCart(context) { ShopCartId = shopCartid };
        }
        public void AddToCart(Product product)
        {
            this._myFoodDbContent.ShopCartItems.Add(new ShopCartItem
            {
                ShopCarId = ShopCartId,
                Product=product,
                Price = product.Price
            });
            _myFoodDbContent.SaveChanges();
        }
        public void DeleteToCart(int id) //TODO голова болит
        {
            var asd = _myFoodDbContent.ShopCartItems.Where(c => (c.ShopCarId == ShopCartId)&&(c.Product.Id== id)).FirstOrDefault();
            this._myFoodDbContent.ShopCartItems.Remove(asd);
            _myFoodDbContent.SaveChanges();

        }
        public List<ShopCartItem> GetShopCartItems()
        {
            return _myFoodDbContent.ShopCartItems.Where(c => c.ShopCarId == ShopCartId).Include(s => s.Product).ToList();
        }
    }
}
