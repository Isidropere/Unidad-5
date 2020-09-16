using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CatalogoProductoDesarrolloWebUASD.Models.ModelDB;

namespace CatalogoProductoDesarrolloWebUASD.Controllers
{
    public class VentasController : Controller
    {
        private CatalogoProducroDBEntities db = new CatalogoProducroDBEntities();

        // GET: Ventas
        public async Task<ActionResult> Index()
        {
            var ventas = db.Ventas.Include(v => v.Cliente).Include(v => v.FormaPago1).Include(v => v.Producto);
            return View(await ventas.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = await db.Ventas.FindAsync(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nombres");
            ViewBag.FomadPagoID = new SelectList(db.FormaPagoes, "FormaPagoID", "FormaPago1");
            ViewBag.ProductoID = new SelectList(db.Productos, "ProductoID", "Producto1");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VentasID,ProductoID,ClienteID,TipoVentas,FormaPago,ValorVenta,FomadPagoID")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Ventas.Add(venta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nombres", venta.ClienteID);
            ViewBag.FomadPagoID = new SelectList(db.FormaPagoes, "FormaPagoID", "FormaPago1", venta.FomadPagoID);
            ViewBag.ProductoID = new SelectList(db.Productos, "ProductoID", "Producto1", venta.ProductoID);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = await db.Ventas.FindAsync(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nombres", venta.ClienteID);
            ViewBag.FomadPagoID = new SelectList(db.FormaPagoes, "FormaPagoID", "FormaPago1", venta.FomadPagoID);
            ViewBag.ProductoID = new SelectList(db.Productos, "ProductoID", "Producto1", venta.ProductoID);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VentasID,ProductoID,ClienteID,TipoVentas,FormaPago,ValorVenta,FomadPagoID")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nombres", venta.ClienteID);
            ViewBag.FomadPagoID = new SelectList(db.FormaPagoes, "FormaPagoID", "FormaPago1", venta.FomadPagoID);
            ViewBag.ProductoID = new SelectList(db.Productos, "ProductoID", "Producto1", venta.ProductoID);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = await db.Ventas.FindAsync(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Venta venta = await db.Ventas.FindAsync(id);
            db.Ventas.Remove(venta);
            await db.SaveChangesAsync();
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
