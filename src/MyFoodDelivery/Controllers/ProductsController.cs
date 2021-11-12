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
    public class ProductsController:Controller
    {
        private readonly IAllProduct _allProduct;
        private readonly IFastFoodCafe _allFastFoodCafe;
        public ProductsController(IAllProduct allProduct, IFastFoodCafe allFastFoodCafe)
        {
            this._allProduct = allProduct;
            this._allFastFoodCafe = allFastFoodCafe;
        }
        [Route("Products/List")]
        [Route("Products/List/{fastFoodCafe}")] //TODO
        public ViewResult List(string fastFoodCafe)
        {
            string _fastFoodCafe = fastFoodCafe;
            IEnumerable<Product> products = null;
            string currFastFoodCafe = string.Empty;
            if (string.IsNullOrEmpty(fastFoodCafe))
            {
                products = _allProduct.Products.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("Mcdonalds", fastFoodCafe, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProduct.Products.Where(i => i.FastFoodCafe.Name.Equals(fastFoodCafe)).OrderBy(i => i.Id);
                    currFastFoodCafe = fastFoodCafe;
                }
                else if (string.Equals("KFC", fastFoodCafe, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProduct.Products.Where(i => i.FastFoodCafe.Name.Equals(fastFoodCafe)).OrderBy(i => i.Id);
                    currFastFoodCafe = fastFoodCafe;
                }
            }
            var carobj = new ProductListViewModel
            {
                AllProduct = products,
                CurrFastFoodCafe = currFastFoodCafe //TODO
            };
            ViewBag.Title = "Страница с продуктами";
            return View(carobj);
        }

    }
}
