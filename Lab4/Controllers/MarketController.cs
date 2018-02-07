using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Lab2.Models;
using Lab4.Models;
using System.Collections.Generic;
using System;

namespace Lab4.Controllers
{
    public class MarketController : Controller
    {
        private MarketList _marketList;

        public MarketController() {
            _marketList = new MarketList();
        }
        public IActionResult List() {

            MarketList mrktList = new MarketList();

            return View(mrktList.MarketLists().ToList());
        }

        public IActionResult MarketProducts(string marketName)
        {
            Initializer initializer = new Initializer();
            ViewData["MarketName"] = marketName;
            var selectedMarkProductPrice = _marketList.selectedMarketProducts(marketName)
                .Sum(x => x.Price);

            var res = new MyVM()
            {
                Selected = _marketList.selectedMarketProducts(marketName),
                SortByPrice = _marketList.selMarPrSortByPrice(marketName),
                SortByAmount = _marketList.selMarPrSortByAmount(marketName),
                sum = Convert.ToInt32(selectedMarkProductPrice)
            };
            return View(res);
        }
    }

    public class MyVM 
    {
        public List<Product> Selected { get; set; }
        public List<Product> SortByPrice { get; set; }
        public List<Product> SortByAmount { get; set; }

        public int sum {get; set;}
    }

}
