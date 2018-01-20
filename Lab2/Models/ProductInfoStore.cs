using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab2.Models
{
    public class ProductInfoStore : IStore<ProductInfo>
    {
        private List<ProductInfo> _cachedCollection;

        public string Path { get; set; }

        public List<ProductInfo> GetCollection()
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

        public ProductInfo ConvertItem(string item)
        {
            var itemList = item.Split(';');

            return new ProductInfo()
            {
                Id = Convert.ToInt32(itemList[0]),
                Parameter = itemList[1],
                Definition = itemList[2],
                ProductId = Convert.ToInt32(itemList[3])
            };
        }
    }
}