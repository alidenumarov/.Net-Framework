using System.Collections.Generic;

namespace Lab4.Models 
{
    public class MarketProductAndInfo 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string MarketName { get; set; }

        public int Rating { get; set; }

        public int Price { get; set; }

        public int Amount { get; set; }

        public int DeliveryPeriod { get; set; }

        public string Parameter { get; set; }

        public string Definition { get; set; }

        public int ProductId { get; set; }

    }
}