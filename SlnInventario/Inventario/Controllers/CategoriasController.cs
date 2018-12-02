using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventario.Models;

namespace Inventario.Controllers
{
    public class CategoriasController : Controller
    {
        private dbInventarioEntities db = new dbInventarioEntities();

        // GET: Categorias
        public ActionResult Index()
        {
            return View(db.tblCategorias.ToList());
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCategorias tblCategorias = db.tblCategorias.Find(id);
            if (tblCategorias == null)
            {
                return HttpNotFound();
            }
            return View(tblCategorias);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCategoria,nombre,descripcion,esActivo")] tblCategorias tblCategorias)
        {
            if (ModelState.IsValid)
            {
                db.tblCategorias.Add(tblCategorias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblCategorias);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCategorias tblCategorias = db.tblCategorias.Find(id);
            if (tblCategorias == null)
            {
                return HttpNotFound();
            }
            return View(tblCategorias);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCategoria,nombre,descripcion,esActivo")] tblCategorias tblCategorias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCategorias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCategorias);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCategorias tblCategorias = db.tblCategorias.Find(id);
            if (tblCategorias == null)
            {
                return HttpNotFound();
            }
            return View(tblCategorias);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCategorias tblCategorias = db.tblCategorias.Find(id);
            db.tblCategorias.Remove(tblCategorias);
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
