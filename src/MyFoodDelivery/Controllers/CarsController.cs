using Microsoft.AspNetCore.Mvc;
using MyFoodDelivery.Data.Interfaces;
using MyFoodDelivery.Data.Models;
using MyFoodDelivery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyFoodDelivery.Data.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;
        public CarsController(IAllCars allCars,ICarsCategory carsCategory)
        {
            this._allCars = allCars;
            this._allCategories = carsCategory;
        }
        public ViewResult List()
        {    
            CarsListViewModels obj = new CarsListViewModels();
            obj.AllCars = _allCars.Cars;
            obj.CurrCategory = "Автомобили";
            return View(obj);
        }
    }
}
