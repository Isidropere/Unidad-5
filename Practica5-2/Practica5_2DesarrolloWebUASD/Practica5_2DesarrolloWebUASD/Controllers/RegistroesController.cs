using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practica5_2DesarrolloWebUASD.Models.ModelDB;

namespace Practica5_2DesarrolloWebUASD.Controllers
{
    public class RegistroesController : Controller
    {
        private EmpleadosDBEntities db = new EmpleadosDBEntities();

        // GET: Registroes
        public ActionResult Index()
        {
            var registroes = db.Registroes.Include(r => r.Departamento).Include(r => r.Empleado);
            return View(registroes.ToList());
        }

        // GET: Registroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.Registroes.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // GET: Registroes/Create
        public ActionResult Create()
        {
            ViewBag.Departamento_DepartamentoID = new SelectList(db.Departamentoes, "DepartamentoID", "Descripcion");
            ViewBag.EmpleadoID = new SelectList(db.Empleadoes, "EmpleadoID", "Nombre");
            return View();
        }

        // POST: Registroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegistroID,Sueldo,DepartemantoID,EmpleadoID,Departamento_DepartamentoID")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                db.Registroes.Add(registro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Departamento_DepartamentoID = new SelectList(db.Departamentoes, "DepartamentoID", "Descripcion", registro.Departamento_DepartamentoID);
            ViewBag.EmpleadoID = new SelectList(db.Empleadoes, "EmpleadoID", "Nombre", registro.EmpleadoID);
            return View(registro);
        }

        // GET: Registroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.Registroes.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            ViewBag.Departamento_DepartamentoID = new SelectList(db.Departamentoes, "DepartamentoID", "Descripcion", registro.Departamento_DepartamentoID);
            ViewBag.EmpleadoID = new SelectList(db.Empleadoes, "EmpleadoID", "Nombre", registro.EmpleadoID);
            return View(registro);
        }

        // POST: Registroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegistroID,Sueldo,DepartemantoID,EmpleadoID,Departamento_DepartamentoID")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departamento_DepartamentoID = new SelectList(db.Departamentoes, "DepartamentoID", "Descripcion", registro.Departamento_DepartamentoID);
            ViewBag.EmpleadoID = new SelectList(db.Empleadoes, "EmpleadoID", "Nombre", registro.EmpleadoID);
            return View(registro);
        }

        // GET: Registroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.Registroes.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // POST: Registroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registro registro = db.Registroes.Find(id);
            db.Registroes.Remove(registro);
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
