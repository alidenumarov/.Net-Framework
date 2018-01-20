using System.Collections.Generic;

namespace Lab2.Models 
{
    public class Product 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Amount { get; set; }

        public int DeliveryPeriod { get; set; }

        public int MarketId { get; set; }

        public List<ProductInfo> ProductInfo { get; set; }
    }
}