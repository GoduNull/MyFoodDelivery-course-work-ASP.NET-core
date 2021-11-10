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
        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;
        public ShopCartController(IAllCars carRepository, ShopCart shopCart)
        {
            _carRep = carRepository;
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
            var item = _carRep.Cars.FirstOrDefault(i=>i.Id==id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }


    }
}
