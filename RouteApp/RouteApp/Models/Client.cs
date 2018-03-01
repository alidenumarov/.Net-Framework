using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RouteApp.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string ClientName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}