using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Lab2.Models;
using Lab4.Models;
using System.Collections.Generic;

namespace Lab4.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List() {
            
            ProductList product = new ProductList();
            
            return View(product.ProductLists().ToList());
        }
    }
}
