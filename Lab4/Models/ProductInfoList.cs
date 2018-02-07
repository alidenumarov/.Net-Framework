using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Lab2.Models;
using Lab4.Models;
using System.Collections.Generic;
using System;

namespace Lab4.Models {
    public class ProductInfoList {
        Initializer initializer = new Initializer();

        public List<ProductInfo> ProductInfoLists() {
            var prInfList = initializer.ProductInfoInitializer()
                        .Select(x => new ProductInfo {
                            Id = x.Id,
                            Parameter = x.Parameter,
                            Definition = x.Definition,
                            ProductId = x.ProductId
                        });
            return prInfList.ToList();
        }
        public List<ProductAndInfo> curProdInfoList = new List<ProductAndInfo>();        
        public List<ProductAndInfo> ProductAndInfos() {
            var prodAndPrInfoList = initializer.ProductInitializer()
                    .Join(initializer.ProductInfoInitializer(), x => x.Id, y => y.ProductId, (x, y) => new {
                        x, y})
                    .ToList();

            var selProdAndInfoList = prodAndPrInfoList
                    .Select(cur => new ProductAndInfo {
                        Name = cur.x.Name,
                        Price = cur.x.Price,
                        Amount = cur.x.Amount,
                        DeliveryPeriod = cur.x.DeliveryPeriod,
                        Parameter = cur.y.Parameter,
                        Definition = cur.y.Definition
                    });

            curProdInfoList = selProdAndInfoList
                    .Select(a => new ProductAndInfo {
                        Name = a.Name,
                        Price = a.Price,
                        Amount = a.Amount,
                        DeliveryPeriod = a.DeliveryPeriod,
                        Parameter = a.Parameter,
                        Definition = a.Definition
                    }).ToList();


            return curProdInfoList.ToList();
        }
            public List<ProductAndInfo> ProductAndInfosByParameter() {
                var sorted = ProductAndInfos()
                        .OrderBy(x => x.Parameter)
                        .ToList();
                return sorted;
            }

            public List<ProductAndInfo> ProductAndInfosLessThan6() {
                var lessThan6 = ProductAndInfos()
                        .Where(x => x.Parameter.Equals("Rating") && Convert.ToInt32(x.Definition) < 6)
                        .ToList();;
                return lessThan6;
            }
    }

}