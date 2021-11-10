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

        private readonly IAllCars _carRep;
        public HomeController(IAllCars carRepository)
        {
            _carRep = carRepository;
        }
        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                FavCars = _carRep.GetFavCars

            };
            return View(homeCars);
        }
    }
}
