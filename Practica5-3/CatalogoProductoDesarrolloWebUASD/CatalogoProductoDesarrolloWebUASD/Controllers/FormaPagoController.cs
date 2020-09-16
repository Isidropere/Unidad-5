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
    public class FormaPagoController : Controller
    {
        private CatalogoProducroDBEntities db = new CatalogoProducroDBEntities();

        // GET: FormaPago
        public async Task<ActionResult> Index()
        {
            return View(await db.FormaPagoes.ToListAsync());
        }

        // GET: FormaPago/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaPago formaPago = await db.FormaPagoes.FindAsync(id);
            if (formaPago == null)
            {
                return HttpNotFound();
            }
            return View(formaPago);
        }

        // GET: FormaPago/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormaPago/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FormaPagoID,TipoVentasID,FormaPago1")] FormaPago formaPago)
        {
            if (ModelState.IsValid)
            {
                db.FormaPagoes.Add(formaPago);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(formaPago);
        }

        // GET: FormaPago/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaPago formaPago = await db.FormaPagoes.FindAsync(id);
            if (formaPago == null)
            {
                return HttpNotFound();
            }
            return View(formaPago);
        }

        // POST: FormaPago/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FormaPagoID,TipoVentasID,FormaPago1")] FormaPago formaPago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formaPago).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(formaPago);
        }

        // GET: FormaPago/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaPago formaPago = await db.FormaPagoes.FindAsync(id);
            if (formaPago == null)
            {
                return HttpNotFound();
            }
            return View(formaPago);
        }

        // POST: FormaPago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FormaPago formaPago = await db.FormaPagoes.FindAsync(id);
            db.FormaPagoes.Remove(formaPago);
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
