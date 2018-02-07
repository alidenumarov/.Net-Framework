using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Lab2.Models;
using System.Collections.Generic;

namespace Lab4.Models {
    public class ProductList {
        Initializer initializer = new Initializer();
        public List<Product> ProductLists() {
            var prList = initializer.ProductInitializer()
                        .Select(x => new Product {
                            Id = x.Id,
                            Name = x.Name,
                            Price = x.Price,
                            Amount = x.Amount,
                            DeliveryPeriod = x.DeliveryPeriod,
                            MarketId = x.MarketId
                        }).ToList();
            
            return prList;
        }
    }
}