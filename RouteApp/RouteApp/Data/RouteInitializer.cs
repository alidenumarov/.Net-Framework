using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RouteApp.Models;
namespace RouteApp.Data
{
    public class RouteInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RouteContext>
    {
        protected override void Seed(RouteContext context)
        {
            var routes = new List<Route>
            {
                new Route {RouteName="Almaty<->Astana", Cost=550, DeliveryPeriod=5},
                new Route {RouteName="Taraz<->Astana", Cost=840, DeliveryPeriod=10},
                new Route {RouteName="Almaty<->Taraz", Cost=215, DeliveryPeriod=2},
                new Route {RouteName="Taraz<->Shymkent", Cost=120, DeliveryPeriod=1},
                new Route {RouteName="Astana<->Pavlodar", Cost=350, DeliveryPeriod=3},
            };
            routes.ForEach(r => context.Routes.Add(r));
            context.SaveChanges();

            var cargos = new List<Cargo>
            {
                new Cargo {Category="First Category", Cost=100 },
                new Cargo {Category="Second Category", Cost=200 },
                new Cargo {Category="Third Category", Cost=300 },
                new Cargo {Category="Fourth Category", Cost=400 },
                new Cargo {Category="Fives Category", Cost=500 },
            };
            cargos.ForEach(c => context.Cargos.Add(c));
            context.SaveChanges();

            var clients = new List<Client>
            {
                new Client {ClientName="Aist Company"},
                new Client {ClientName="Murat Alibekov"},
                new Client {ClientName="BobBon Company"},
                new Client {ClientName="Deeper Autonomy"},
                new Client {ClientName="Khan Li Don"},
            };
            clients.ForEach(c => context.Clients.Add(c));
            context.SaveChanges();

            var orders = new List<Order>
            {
                new Order { RouteId=1, CargoId=1, ClientId=1, Count=3, Status="delivered"},
                new Order { RouteId=1, CargoId=3, ClientId=2, Count=31, Status="delivered" },
                new Order { RouteId=2, CargoId=4, ClientId=1, Count=1, Status="delivered" },
                new Order { RouteId=2, CargoId=1, ClientId=4, Count=6, Status="delivered" },
                new Order { RouteId=3, CargoId=1, ClientId=2, Count=20, Status="canceled" },
                new Order { RouteId=3, CargoId=3, ClientId=3, Count=15, Status="with delay" },
                new Order { RouteId=4, CargoId=2, ClientId=1, Count=5, Status="canceled" },
                new Order { RouteId=4, CargoId=5, ClientId=5, Count=10, Status="canceled" },
                new Order { RouteId=4, CargoId=1, ClientId=1, Count=10, Status="canceled" },
                new Order { RouteId=5, CargoId=2, ClientId=3, Count=5, Status="with delay" },
                new Order { RouteId=5, CargoId=4, ClientId=1, Count=12, Status="with delay" },
                new Order { RouteId=5, CargoId=5, ClientId=5, Count=7, Status="canceled" },
            };
            orders.ForEach(o => context.Orders.Add(o));
            context.SaveChanges();
        }
    }
}