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
    public class ProductosController : Controller
    {
        private dbInventarioEntities db = new dbInventarioEntities();

        // GET: Productos
        public ActionResult Index()
        {
            var tblProductos = db.tblProductos.Include(t => t.tblCategorias);
            return View(tblProductos.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProductos tblProductos = db.tblProductos.Find(id);
            if (tblProductos == null)
            {
                return HttpNotFound();
            }
            return View(tblProductos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {

            List<spsObtenerCategoriasActivas_Result> fil = db.spsObtenerCategoriasActivas(true).ToList();
            ViewBag.idCategoria = new SelectList(fil, "idCategoria", "nombre");
            return View();
            //Solo muestra los registros activos en el dropdown list
            //var filtrados = db.tblCategorias.Where(x => x.esActivo == true);
            //ViewBag.idCategoria = new SelectList(filtrados, "idCategoria", "nombre");
            //return View();

            //ViewBag.idCategoria = new SelectList(db.tblCategorias, "idCategoria", "nombre");
            //return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProducto,nombre,descripcion,cantidad,marca,fechaCreacion,idCategoria,esActivo,unidadMedida")] tblProductos tblProductos)
        {
            if (ModelState.IsValid)
            {
                db.tblProductos.Add(tblProductos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.tblCategorias, "idCategoria", "nombre", tblProductos.idCategoria);
            return View(tblProductos);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProductos tblProductos = db.tblProductos.Find(id);
            if (tblProductos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.tblCategorias, "idCategoria", "nombre", tblProductos.idCategoria);
            return View(tblProductos);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProducto,nombre,descripcion,cantidad,marca,fechaCreacion,idCategoria,esActivo,unidadMedida")] tblProductos tblProductos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblProductos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoria = new SelectList(db.tblCategorias, "idCategoria", "nombre", tblProductos.idCategoria);
            return View(tblProductos);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProductos tblProductos = db.tblProductos.Find(id);
            if (tblProductos == null)
            {
                return HttpNotFound();
            }
            return View(tblProductos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblProductos tblProductos = db.tblProductos.Find(id);
            db.tblProductos.Remove(tblProductos);
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
