using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebLab6.Models;
namespace WebLab6.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private static List<Product> products;

        public ProductsController()
        {
            if (products == null)
            {
                products = new List<Product>();
                products.Add(new Product { Id = 1, Name = "Cola", Price = 3 });
                products.Add(new Product { Id = 2, Name = "Tomato", Price = 1.7 });
                products.Add(new Product { Id = 3, Name = "Pizza", Price = 5.3 });
            }
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return products;
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return products.First(x => x.Id == id);
        }

        [HttpPost]
        public void Post([FromBody] Product product)
        {
            product.Id = products.Max(x => x.Id) + 1;
            products.Add(product);
        }

        [HttpPut]
        public void Put([FromBody] Product product)
        {
            var curProd = products.First(x => x.Id == product.Id);
            curProd.Name = product.Name;
            curProd.Price = product.Price;
        }

        [HttpPatch]
        public void Patch(int id, string name)
        {
            var curProd = products.First(x => x.Id == id);
            curProd.Name = name;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = products.First(x => x.Id == id);
            products.Remove(item);
        }
    }
}