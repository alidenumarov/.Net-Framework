using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RouteApp.Models
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public float Cost { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}