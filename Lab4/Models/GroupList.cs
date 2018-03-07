using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Lab2.Models;
using Lab4.Models;
using System.Collections.Generic;
using System;

namespace Lab4.Models {
    public class GroupList {
        Initializer initializer = new Initializer();

        public List<MarketProductAndInfo> curProdInfoList = new List<MarketProductAndInfo>();        
        public List<MarketProductAndInfo> MarketProductAndInfos() {
            var prodAndPrInfoList = initializer.ProductInitializer()
                    .Join(initializer.ProductInfoInitializer(), x => x.Id, y => y.ProductId, (x, y) => new {
                        x, y})
                    .ToList();

            var marketProdAndInfo = initializer.MarketInitializer()
                    .Join(prodAndPrInfoList, cur1 => cur1.Id, cur2 => cur2.x.MarketId, (cur1, cur2) => new {
                        cur1,
                        cur2
                    });

            var selProdAndInfoList = marketProdAndInfo
                    .Select(cur => new MarketProductAndInfo {
                        Name = cur.cur2.x.Name,
                        MarketName = cur.cur1.MarketName,
                        Price = cur.cur2.x.Price,
                        Amount = cur.cur2.x.Amount,
                        DeliveryPeriod = cur.cur2.x.DeliveryPeriod,
                        Parameter = cur.cur2.y.Parameter,
                        Definition = cur.cur2.y.Definition,
                        Rating = cur.cur1.Rating
                    });

            curProdInfoList = selProdAndInfoList
                    .Select(a => new MarketProductAndInfo {
                        Name = a.Name,
                        Price = a.Price,
                        Amount = a.Amount,
                        DeliveryPeriod = a.DeliveryPeriod,
                        Parameter = a.Parameter,
                        Definition = a.Definition,
                        MarketName = a.MarketName,
                        Rating = a.Rating
                    })
                    .ToList();

            return curProdInfoList.ToList();
        }

        public List<MarketProductAndInfo> AvPrRatInMarket() {
            var _av = MarketProductAndInfos()
                .Where(x => x.Parameter.Equals("Rating"))
                .Select(x => Convert.ToInt32(x.Definition))
                .Average();

            // var _avRatingPrInMarket = MarketProductAndInfos()
            //     .Where(x => x.Parameter.Equals("Rating") && Convert.ToDouble(x.Rating) < _av)
            //     .ToList();
            var _avRatingPrInMarket = MarketProductAndInfos()
                .Where(x => x.Parameter.Equals("Rating"))
                .ToList();
            return _avRatingPrInMarket;
        }


    }

}