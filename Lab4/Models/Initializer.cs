using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Lab2.Models;
using System.Collections.Generic;

namespace Lab4.Models {
    public class Initializer {
        static readonly string marketPath = "App_Data/markets.csv";
        static readonly string productsPath = "App_Data/products.csv";
        static readonly string productInfoPath = "App_Data/productInfo.csv";
        MarketStore marketStore = new MarketStore() { Path = marketPath };
        ProductStore productStore = new ProductStore() { Path = productsPath };
        ProductInfoStore productInfoStore = new ProductInfoStore() { Path = productInfoPath };
        public List<Product> ProductInitializer() {
            var productList = productStore.GetCollection();
            return productList;            
        }
        public List<Market> MarketInitializer() {
            var marketList = marketStore.GetCollection();
            return marketList;            
        }
        public List<ProductInfo> ProductInfoInitializer() {
            var productInfoList = productInfoStore.GetCollection();
            return productInfoList;            
        }


    }
}