using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RouteApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RouteApp.Data
{
    public class RouteContext : DbContext
    {
        public RouteContext() : base("RouteContext") { }

        public DbSet<Route> Routes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}