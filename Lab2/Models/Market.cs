using System.Collections.Generic;

namespace Lab2.Models 
{
    public class Market 
    {
        public int Id { get; set; }

        public string MarketName { get; set; }

        public int Rating { get; set; }

        public List<Product> Products { get; set; }
    }
}