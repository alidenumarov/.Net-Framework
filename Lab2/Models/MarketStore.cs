using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab2.Models
{
    public class MarketStore : IStore<Market>
    {
        private List<Market> _cachedCollection;

        public string Path { get; set; }

        public List<Market> GetCollection()
        {
            if(_cachedCollection == null)
            {
                var data = File.ReadAllLines(Path);
                _cachedCollection = data
                    .Skip(1)
                    .Select(x => ConvertItem(x))
                    .ToList();
            }
            
            return _cachedCollection;
        }

        public Market ConvertItem(string item)
        {
            var itemList = item.Split(';');

            return new Market()
            {
                Id = Convert.ToInt32(itemList[0]),
                MarketName = itemList[1],
                Rating = Convert.ToInt32(itemList[2])
            };
        }
    }
}