using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gasolineras.Models;
using Newtonsoft.Json;

namespace Gasolineras.Controllers
{
    public class GasolinerasController : Controller
    {
        private GasolinerasEntities1 db = new GasolinerasEntities1();

        // GET: Gasolineras

        public ActionResult Index()
        {

           
            return View();
        }

        public JsonResult GetMapMarker()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var ListaGasolineras = db.Gasolineras.ToList();

            return Json(ListaGasolineras, JsonRequestBehavior.AllowGet);
        }

        // GET: Gasolineras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gasolinera gasolinera = db.Gasolineras.Find(id);
            if (gasolinera == null)
            {
                return HttpNotFound();
            }
            return View(gasolinera);
        }

        // GET: Gasolineras/Create
        public ActionResult Create()
        {
            ViewBag.Amenidades = new SelectList(db.Amenidades, "Id", "Descripcion");
            ViewBag.Marca = new SelectList(db.Marcas, "Id", "Descripcion");
            return View();
        }

        // POST: Gasolineras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Latitud,Longitud,Nombre,Marca,Amenidades,PrecioMagna,PrecioPremium,PrecioDiesel,HoraApertura,HoraCierre")] Gasolinera gasolinera, int[] Amenidades)
        {
            if (ModelState.IsValid)
            {
                string amenidades = Amenidades != null ? String.Join(",", Amenidades.Select(p => p.ToString()).ToArray()) : null;
                gasolinera.Amenidades = amenidades;
                db.Gasolineras.Add(gasolinera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Marca = new SelectList(db.Marcas, "Id", "Descripcion", gasolinera.Marca);
            return View(gasolinera);
        }

        // GET: Gasolineras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gasolinera gasolinera = db.Gasolineras.Find(id);
            if (gasolinera == null)
            {
                return HttpNotFound();
            }
            ViewBag.Marca = new SelectList(db.Marcas, "Id", "Descripcion", gasolinera.Marca);
            return View(gasolinera);
        }

        // POST: Gasolineras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Latitud,Longitud,Nombre,Marca,Amenidades,PrecioMagna,PrecioPremium,PrecioDiesel,HoraApertura,HoraCierre")] Gasolinera gasolinera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gasolinera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Marca = new SelectList(db.Marcas, "Id", "Descripcion", gasolinera.Marca);
            return View(gasolinera);
        }

        // GET: Gasolineras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gasolinera gasolinera = db.Gasolineras.Find(id);
            if (gasolinera == null)
            {
                return HttpNotFound();
            }
            return View(gasolinera);
        }

        // POST: Gasolineras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gasolinera gasolinera = db.Gasolineras.Find(id);
            db.Gasolineras.Remove(gasolinera);
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
