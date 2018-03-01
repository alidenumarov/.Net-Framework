using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RouteApp.Data;
using RouteApp.Models;

namespace RouteApp.Controllers
{
    public class OrderController : Controller
    {
        private RouteContext db = new RouteContext();

        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Cargo).Include(o => o.Client).Include(o => o.Route);
            return View(orders.ToList());
        }

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            ViewBag.CargoId = new SelectList(db.Cargos, "Id", "Category");
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "ClientName");
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "RouteName");
            return View();
        }
 

        // POST: Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RouteId,CargoId,ClientId,Count,Status")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CargoId = new SelectList(db.Cargos, "Id", "Category", order.CargoId);
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "ClientName", order.ClientId);
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "RouteName", order.RouteId);
            return View(order);
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CargoId = new SelectList(db.Cargos, "Id", "Category", order.CargoId);
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "ClientName", order.ClientId);
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "RouteName", order.RouteId);
            return View(order);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RouteId,CargoId,ClientId,Count,Status")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CargoId = new SelectList(db.Cargos, "Id", "Category", order.CargoId);
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "ClientName", order.ClientId);
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "RouteName", order.RouteId);
            return View(order);
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
