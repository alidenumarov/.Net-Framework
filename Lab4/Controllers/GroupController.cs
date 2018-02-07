using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Lab2.Models;
using Lab4.Models;
using System.Collections.Generic;

namespace Lab4.Controllers
{
    public class GroupController : Controller
    {
        GroupList _groupList;

        public GroupController() {
            _groupList = new GroupList();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List() {
            var _marketProdAndIfo = _groupList.MarketProductAndInfos();
            return View(_marketProdAndIfo);            
        }

        public IActionResult AvProductRatingWithMarket() {
            var _avProductRatingWithMarket = _groupList.AvPrRatInMarket();
            return View(_avProductRatingWithMarket);
        }
    }
}
