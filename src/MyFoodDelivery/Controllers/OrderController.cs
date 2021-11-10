using Microsoft.AspNetCore.Mvc;
using MyFoodDelivery.Data.Interfaces;
using MyFoodDelivery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDelivery.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders Allorders;
        private readonly ShopCart shopCart;
        public OrderController(IAllOrders Allorders, ShopCart shopCart)
        {
            this.Allorders = Allorders;
            this.shopCart = shopCart;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.ListShopItems = shopCart.GetShopCartItems();
            if (shopCart.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("","У вас должны быть товары");
            }
            if (ModelState.IsValid)
            {
                Allorders.createOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }


    }
}
