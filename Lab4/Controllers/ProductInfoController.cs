using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Lab2.Models;
using Lab4.Models;
using System.Collections.Generic;

namespace Lab4.Controllers
{
    public class ProductInfoController : Controller
    {
        ProductInfoList _productInfoList;

        public ProductInfoController() {
            _productInfoList = new ProductInfoList();
        }
        Initializer initializer = new Initializer();
        public IActionResult List() {
            // ProductInfoList productInfoList = new ProductInfoList();
            var prInfList = _productInfoList.ProductInfoLists();
            return View(prInfList);
        }

        public IActionResult Info() {
            var prodInfo = _productInfoList.ProductAndInfos();
            return View(prodInfo);
        }

        public IActionResult ByParameter() {
            var prodInfo = _productInfoList.ProductAndInfosByParameter();
            return View(prodInfo);
        }

        public IActionResult LessThan6() {
            var prodInfo = _productInfoList.ProductAndInfosLessThan6();
            return View(prodInfo);
        }
    }
}
