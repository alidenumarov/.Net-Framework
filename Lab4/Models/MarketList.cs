using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Lab2.Models;
using System.Collections.Generic;

namespace Lab4.Models {
    public class MarketList {
        Initializer initializer = new Initializer();
        public List<Market> MarketLists() {
            var prList = initializer.MarketInitializer()
                        .Select(x => new Market {
                            Id = x.Id,
                            MarketName = x.MarketName,
                            Rating = x.Rating
                        }).ToList();
            
            return prList;
        }

        public List<Product> selectedMarketProducts(string marketName) {
            var selectedMarket = initializer.MarketInitializer()
                    .First(x => x.MarketName.Equals(marketName));
            selectedMarket.Products = initializer.ProductInitializer()
                    .Where(x => x.MarketId == selectedMarket.Id)
                    .ToList();
            return selectedMarket.Products;
        }

        public List<Product> selMarPrSortByPrice(string marketName) {
            var selectedMarket = initializer.MarketInitializer()
                    .First(x => x.MarketName.Equals(marketName));
            selectedMarket.Products = initializer.ProductInitializer()
                    .Where(x => x.MarketId == selectedMarket.Id)
                    .OrderBy(x => x.Price)
                    .ToList();
            return selectedMarket.Products;
        }
        public List<Product> selMarPrSortByAmount(string marketName) {
            var selectedMarket = initializer.MarketInitializer()
                    .First(x => x.MarketName.Equals(marketName));
            selectedMarket.Products = initializer.ProductInitializer()
                    .Where(x => x.MarketId == selectedMarket.Id)
                    .OrderBy(x => x.Amount)
                    .ToList();
            return selectedMarket.Products;
        }
        


    }
}