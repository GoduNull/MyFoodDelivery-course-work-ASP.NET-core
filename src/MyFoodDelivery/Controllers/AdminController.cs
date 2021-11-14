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
    public class AdminController : Controller
    {
        private const int _passwordAdmin = 1234;
        private readonly IAllProduct allProduct;
        private readonly ShopCart shopCart;
        //https://localhost:44302/Admin/Admins?password=1234
        public AdminController(IAllProduct allProduct, ShopCart shopCart)
        {
            this.allProduct = allProduct;
            this.shopCart = shopCart;
        }
        public IActionResult AddProduct(Product product)
        {

            ModelState.AddModelError("", "У вас должны быть товары");
            if (ModelState.IsValid)
            {
                return RedirectToAction("Complete");
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Complete(Product product) //Добавление продукты в бд
        {
            allProduct.AddProduct(product);
            ViewBag.Message = "Продукт успешно добавлен";
            return View();
        }
        public IActionResult Admins(int password)
        {
            if (_passwordAdmin == password)
            {
                return RedirectToAction("AddProduct");
            }
            return View();
        }
    }
}
