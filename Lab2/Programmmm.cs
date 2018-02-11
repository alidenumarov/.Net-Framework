using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lab2.Models;

namespace Lab2
{
    public class Programmmm
    {
        static readonly string marketPath = "App_Data/markets.csv";
        static readonly string productsPath = "App_Data/products.csv";
        static readonly string productInfoPath = "App_Data/productInfo.csv";

        static void Main(string[] args)
        {
            var marketStore = new MarketStore() { Path = marketPath };
            var productStore = new ProductStore() { Path = productsPath };
            var productInfoStore = new ProductInfoStore() { Path = productInfoPath };

            // example 1. get markets with products
            // group markets with products

            var productList = productStore.GetCollection();
            var marketList = marketStore.GetCollection();
            var productInfoList = productInfoStore.GetCollection();

            foreach(var item in marketList)
            {
                item.Products = productList
                    .Where(x => x.MarketId == item.Id)
                    .ToList();
            }

            Console.WriteLine("\n");
            Console.WriteLine("Шаг 1. Работа с файлами\n1. Извлечь данные из файлов (csv);");
            Console.WriteLine("2. Отобразить все данные из этих файлов в виде списка;\n");
            var prodTemplate = "{0} | {1} | {2} | {3} | {4}";
            Console.WriteLine(string.Format(prodTemplate, 
                "Id", 
                "Name", 
                "Price", 
                "Amount",
                "Delivery Perion (days)"));
            foreach(var item in marketList) {
                foreach(var prod in item.Products) {
                    Console.WriteLine(string.Format(prodTemplate,
                        prod.Id, 
                        prod.Name,
                        prod.Price,
                        prod.Amount,
                        prod.DeliveryPeriod));
                }
            }
        
            Console.WriteLine("\n");

            foreach(var item in productList) {
                item.ProductInfo = productInfoList.Where(x => x.ProductId == item.Id).ToList();
            }

            var productInfoListTemplate = "{0} |  {1} |  {2}";
            Console.WriteLine(string.Format(productInfoListTemplate,
                "Id", 
                "Parameter", 
                "Definition"));

            foreach(var i in productList) {
                foreach(var prodInfo in i.ProductInfo) {
                    Console.WriteLine(string.Format(productInfoListTemplate,
                        prodInfo.Id,
                        prodInfo.Parameter,
                        prodInfo.Definition));
                }
            }

            Console.WriteLine("\n");
            Console.WriteLine(string.Format(productInfoListTemplate,
                "Id", 
                "Name", 
                "Rating"));
            foreach(var i in marketList) {
                Console.WriteLine(string.Format(productInfoListTemplate,
                    i.Id,
                    i.MarketName,
                    i.Rating));
            }
            
            Console.WriteLine("\n\nШаг 2. Обработка Market");
            Console.WriteLine("\n1. Отобразить список продуктов;\n");

            foreach(var i in marketList) {
                Console.Write(i.MarketName + " | ");
            }
            Console.WriteLine();
            string enteredMarketName = Console.ReadLine();
            
            var selectedMarket = marketList
                .First(x => x.MarketName.Equals(enteredMarketName));

            selectedMarket.Products = productList
                .Where(x => x.MarketId == selectedMarket.Id)
                .ToList();

            foreach(var item in selectedMarket.Products) {
                Console.WriteLine(item.Id + " " + item.Name);
            }

            Console.WriteLine("\n2. Вывести сумму цен всех продуктов выбранного Market; ");
            
            Console.WriteLine("= " + selectedMarket.Products.Sum(x => x.Price));

            Console.WriteLine("\n\n3. Отсортировать по цене (от меньшего к большему) и вывести продукты выбранного Market;");
            selectedMarket.Products = productList
                .Where(x => x.MarketId == selectedMarket.Id)
                .OrderBy(x => x.Price)
                .ToList();

            foreach(var cur in selectedMarket.Products) {
                Console.WriteLine(cur.Price + " " + cur.Name);
            }
            
            Console.WriteLine("\n4. Отсортировать по кол-ву продуктов и вывести их (по выбранному Market);");
            selectedMarket.Products = productList
                .Where(x => x.MarketId == selectedMarket.Id)
                .OrderBy(x => x.Amount)
                .ToList();
            foreach(var cur in selectedMarket.Products) {
                Console.WriteLine(cur.Amount + " " + cur.Name);
            }

            Console.WriteLine("\n\nШаг 3. Работа с ProductInfo\n\n1. Сгруппировать Product и Product Info и отобразить их;\n");
            Console.WriteLine("Group Product and PrInfo by their Name\n");
            string pr6LessStr = "{0} |  {1} |  {2}  |  {3} |  {4} |  {5}";
            Console.WriteLine(string.Format(pr6LessStr,
                    "Name",
                    "Price",
                    "Amount",
                    "DeliveryPeriod",
                    "Parameter",
                    "Definition"));

            var proddListttt = productList
                .Join(productInfoList, x => x.Id, y => y.ProductId, (x, y) => new {
                    x.Name,
                    x.Price,
                    x.Amount,
                    x.DeliveryPeriod,
                    y.Parameter,
                    y.Definition})
                .GroupBy(x => x.Name)
                .ToList();

            foreach(var itm in proddListttt) {
                foreach(var i in itm) {
                    Console.WriteLine(string.Format(pr6LessStr,
                    i.Name,
                    i.Price,
                    i.Amount,
                    i.DeliveryPeriod,
                    i.Parameter,
                    i.Definition));
                }
                Console.WriteLine("\n");
            }
            
            Console.WriteLine("\n2. Отсортировать название параметра в Product Info;");
            var listOfProdInfo = productInfoList
                .OrderBy(x => x.Parameter);

            string listOfProdInfoStr = "{0} |  {1} |  {2}";
            Console.WriteLine(string.Format(productInfoListTemplate,
                "Id", 
                "Parameter", 
                "Definition"));
            foreach(var cur in listOfProdInfo) {
                Console.WriteLine(string.Format(listOfProdInfoStr,
                    cur.Id,
                    cur.Parameter,
                    cur.Definition));
            }
            
            Console.WriteLine("\n3. Выделить все продукты с рейтингом менее 6;");

            var prodRating6Less = productList
                    .Join(productInfoList, x => x.Id, y => y.ProductId, (x, y) => new {
                        x.Name,
                        y.Definition,
                        y.Parameter})
                    .Where(x => x.Parameter.Equals("Rating") && Convert.ToInt32(x.Definition) < 6)
                    .ToList();

            foreach(var print in prodRating6Less) {
                Console.WriteLine(print.Definition + " " + print.Name);
            }
        
            Console.WriteLine("\n\nШаг 4. Общее\n\n1. Сгруппировать Market, Product, ProductInfo и вывести;\n");

            var grMarProd = marketList
                    .Join(productList, x => x.Id, y => y.MarketId, (x, y) => new {
                        x.MarketName,
                        x.Rating,
                        y.Id,
                        y.Name,
                        y.Price,
                        y.Amount,
                        y.DeliveryPeriod});

            var grMarProdPrInf = grMarProd
                    .Join(productInfoList, x => x.Id, y => y.ProductId, (x, y) => new {
                        x.MarketName,
                        x.Rating,
                        x.Name,
                        x.Price,
                        x.Amount,
                        x.DeliveryPeriod,
                        y.Parameter,
                        y.Definition})
                    .GroupBy(x => x.MarketName);

            string grMarProdPrInfStr =  "{0} |  {1} |  {2}  |  {3} |  {4} |  {5}  |  {6}  |  {7}";
            
            Console.WriteLine(string.Format(grMarProdPrInfStr,
                        "MarketName",
                        "Rating",
                        "Name",
                        "Price",
                        "Amount",
                        "DeliveryPeriod",
                        "Parameter",
                        "Definition\n"));

            foreach(var grMPP in grMarProdPrInf) {
                foreach(var g in grMPP) {
                    Console.WriteLine(string.Format(grMarProdPrInfStr,
                        g.MarketName,
                        g.Rating,
                        g.Name,
                        g.Price,
                        g.Amount,
                        g.DeliveryPeriod,
                        g.Parameter,
                        g.Definition));
                }
            }

            var grMarRatAndProdRat = grMarProd
                    .Join(productInfoList, x => x.Id, y => y.ProductId, (x, y) => new {
                        x.MarketName,
                        x.Rating,
                        x.Name,
                        x.Price,
                        x.Amount,
                        x.DeliveryPeriod,
                        y.Parameter,
                        y.Definition})
                    .Where(x => x.Parameter.Equals("Rating"));

            foreach(var grMPP in grMarProdPrInf) {
                var avPrInMarket = grMPP
                    .Where(x => x.Parameter.Equals("Rating"))
                    .Select(x => Convert.ToInt32(x.Definition))
                    .ToList();
                
                // double avProductRat = avPrInMarket
                //     .Where(x => x.Parameter.Equals("Rating")
                //     .Average(x => Convert.ToDouble(x.Definition));
                
                // foreach(var g in grMPP) {
                //     Console.WriteLine(string.Format(grMarProdPrInfStr,
                //         g.MarketName,
                //         g.Rating,
                //         g.Name,
                //         g.Price,
                //         g.Amount,
                //         g.DeliveryPeriod,
                //         g.Parameter,
                //         g.Definition));
                        
                //     Console.WriteLine(avProductRat + "");
                // }
                // Console.WriteLine("\n");
            }

            // for(int i = 0; i < grMarRatAndProdRat.Count(); i++) {
                
            // }

            //double avProductRating = grMarRatAndProdRat.Average(x => Convert.ToDouble(x.Definition));

            Console.WriteLine("\n2. Сравнить рейтинг Market с средним значением рейтингов продуктов. Если рейтинг Market ниже, то выделить Market\n");
            foreach(var grMPP in grMarProdPrInf) {
                var avPrInMarket = grMPP
                    .Where(x => x.Parameter.Equals("Rating"))
                    .Select(x => Convert.ToInt32(x.Definition))
                    .Average();

                Console.WriteLine("\nAverage rating of product: " + avPrInMarket + "\n");
                string addedTick = "";
                foreach(var g in grMPP) {
                    if(Convert.ToDouble( g.Rating) < Convert.ToDouble(avPrInMarket)) {
                        addedTick = "      IS LESS";
                    } else {
                        addedTick = "";
                    }
                }
                foreach(var g in grMPP) {
                    Console.WriteLine(string.Format(grMarProdPrInfStr,
                        g.MarketName,
                        g.Rating + addedTick,
                        g.Name,
                        g.Price,
                        g.Amount,
                        g.DeliveryPeriod,
                        g.Parameter,
                        g.Definition));
                }
            }
        }
    }
}
