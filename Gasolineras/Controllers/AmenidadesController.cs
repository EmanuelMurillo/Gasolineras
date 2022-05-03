using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gasolineras.Models;

namespace Gasolineras.Controllers
{
    public class AmenidadesController : Controller
    {
        private GasolinerasEntities1 db = new GasolinerasEntities1();

        // GET: Amenidades
        public ActionResult Index()
        {
            return View(db.Amenidades.ToList());
        }

        // GET: Amenidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amenidade amenidade = db.Amenidades.Find(id);
            if (amenidade == null)
            {
                return HttpNotFound();
            }
            return View(amenidade);
        }

        // GET: Amenidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Amenidades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion")] Amenidade amenidade)
        {
            if (ModelState.IsValid)
            {
                db.Amenidades.Add(amenidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(amenidade);
        }

        // GET: Amenidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amenidade amenidade = db.Amenidades.Find(id);
            if (amenidade == null)
            {
                return HttpNotFound();
            }
            return View(amenidade);
        }

        // POST: Amenidades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion")] Amenidade amenidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(amenidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(amenidade);
        }

        // GET: Amenidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amenidade amenidade = db.Amenidades.Find(id);
            if (amenidade == null)
            {
                return HttpNotFound();
            }
            return View(amenidade);
        }

        // POST: Amenidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Amenidade amenidade = db.Amenidades.Find(id);
            db.Amenidades.Remove(amenidade);
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
