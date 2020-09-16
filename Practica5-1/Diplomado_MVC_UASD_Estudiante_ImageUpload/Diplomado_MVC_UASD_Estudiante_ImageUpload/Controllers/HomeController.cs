using Diplomado_MVC_UASD_Estudiante_ImageUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplomado_MVC_UASD_Estudiante_ImageUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file!=null)
            {
                EstudianteDBEntities db = new EstudianteDBEntities();
                string imageName = System.IO.Path.GetFileName(file.FileName);
                string physicalpath = Server.MapPath("~/Images/" + imageName);
                file.SaveAs(physicalpath);
                tblEstudiante Estudiente = new tblEstudiante();
                Estudiente.Nombes = Request.Form["Nombes"];
                Estudiente.Apellidos = Request.Form["Apellidos"];
                Estudiente.Direccion = Request.Form["Direccion"];
                Estudiente.Telefono = Request.Form["Telefono"];
                Estudiente.Cedula = Request.Form["Cedula"];
                Estudiente.ImagenURL = imageName;
                db.tblEstudiantes.Add(Estudiente);
                db.SaveChanges();

            }
            return RedirectToAction("../home/Detalle/");
        }

        public ActionResult Detalle()
        {

            return View();
        }

        public ActionResult Estudiantes()
        {

            return View();
        }



    }
}