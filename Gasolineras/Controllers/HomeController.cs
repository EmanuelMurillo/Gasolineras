using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gasolineras.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ruta()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Bienvenido()
        {
            ViewBag.Message = "Página de Bienvenida.";

            return View();
        }
    }
}