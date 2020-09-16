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
    public class ProductosController : Controller
    {
        private CatalogoProducroDBEntities db = new CatalogoProducroDBEntities();

        // GET: Productos
        public async Task<ActionResult> Index()
        {
            return View(await db.Productos.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = await db.Productos.FindAsync(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string imageName = System.IO.Path.GetFileName(file.FileName);
                    string physicalpath = Server.MapPath("~/Imagen/Producto/" + imageName);
                    file.SaveAs(physicalpath);
                    Producto Productos = new Producto();
                    Productos.Producto1 = Request.Form["Producto1"];
                    Productos.Descripcion = Request.Form["Descripcion"];
                    Productos.Precio = Convert.ToDouble(Request.Form["Precio"]);
                    Productos.CantExistencia = Convert.ToInt32(Request.Form["CantExistencia"]);
                    Productos.ImageURL = imageName;
                    db.Productos.Add(Productos);
                    db.SaveChanges();

                }
            }

            return RedirectToAction("../Productos/Index/");
        }

        // GET: Productos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = await db.Productos.FindAsync(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }


        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
      

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit([Bind(Include = "ProductoID,Producto1,Descripcion,Precio,CantExistencia,ImageURL")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                if (producto.ImageURL != null)
                {
                    //string imageName = System.IO.Path.GetFileName(file.FileName);
                    //string physicalpath = Server.MapPath("~/Imagen/Producto/" + imageName);
                    //file.SaveAs(physicalpath);
                    db.Entry(producto).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }

                return RedirectToAction("Index");
            }
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = await db.Productos.FindAsync(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Producto producto = await db.Productos.FindAsync(id);
            db.Productos.Remove(producto);
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
