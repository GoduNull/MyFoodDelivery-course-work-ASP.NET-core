using Microsoft.AspNetCore.Mvc;
using MyFoodDelivery.Data.Interfaces;
using MyFoodDelivery.Data.Models;
using MyFoodDelivery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllProduct _productRep;
        private readonly ShopCart _shopCart;
        public ShopCartController(IAllProduct productRep, ShopCart shopCart)
        {
            _productRep = productRep;
            _shopCart = shopCart;

        }
        public ViewResult Index()
        {
            var items = _shopCart.GetShopCartItems();
            _shopCart.ListShopItems = items;
            var obj = new ShopCartViewModel
            {
                ShopCart = _shopCart
            };
            return View(obj);
        }
        public RedirectToActionResult AddToCart(int id)
        {
            var item = _productRep.Products.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult Delete(int id)
        {
            _shopCart.DeleteToCart(id);
            return RedirectToAction("Index");
        }

    }
}
