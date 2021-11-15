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
    public class HomeController : Controller
    {
        private readonly IAllProduct _productRep;
        public HomeController(IAllProduct productRep)
        {
            _productRep = productRep;
        }
        public ViewResult Index()
        {
            var homeProduct = new HomeViewModel
            {
                FavProduct = _productRep.GetFavCars

            };
            return View(homeProduct);
        }
    }
}
