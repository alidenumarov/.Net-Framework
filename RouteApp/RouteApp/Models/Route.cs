using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RouteApp.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string RouteName { get; set; }
        public float Cost { get; set; }
        public int DeliveryPeriod { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}