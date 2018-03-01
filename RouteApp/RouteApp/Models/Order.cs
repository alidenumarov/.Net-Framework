using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RouteApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int CargoId { get; set; }
        public int ClientId { get; set; }
        public int Count { get; set; }
        public string Status { get; set; }
        
        public virtual Route Route { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual Client Client { get; set; }

    }
}