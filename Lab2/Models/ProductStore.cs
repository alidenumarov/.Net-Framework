using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab2.Models
{
    public class ProductStore : IStore<Product>
    {
        private List<Product> _cachedCollection;
        
        public string Path { get; set; }
        public List<Product> GetCollection()
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

        public Product ConvertItem(string item)
        {
            var itemList = item.Split(';');

            return new Product()
            {
                Id = Convert.ToInt32(itemList[0]),
                Name = itemList[1],
                Price = Convert.ToInt32(itemList[2]),
                Amount = Convert.ToInt32(itemList[3]),
                DeliveryPeriod = Convert.ToInt32(itemList[4]),
                MarketId = Convert.ToInt32(itemList[5])
            };
        }
    }
}