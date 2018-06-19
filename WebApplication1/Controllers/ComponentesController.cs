using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ComponentesController : Controller
    {
        private ProjetosEntities db = new ProjetosEntities();

        // GET: Componentes
        public ActionResult Index()
        {
            return View(db.COMPONENTE.ToList());
        }

        // GET: Componentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPONENTE cOMPONENTE = db.COMPONENTE.Find(id);
            if (cOMPONENTE == null)
            {
                return HttpNotFound();
            }
            return View(cOMPONENTE);
        }

        // GET: Componentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Componentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idComponente,ramTotal,ramDispo,usoCpu")] COMPONENTE cOMPONENTE)
        {
            if (ModelState.IsValid)
            {
                db.COMPONENTE.Add(cOMPONENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cOMPONENTE);
        }

        // GET: Componentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPONENTE cOMPONENTE = db.COMPONENTE.Find(id);
            if (cOMPONENTE == null)
            {
                return HttpNotFound();
            }
            return View(cOMPONENTE);
        }

        // POST: Componentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idComponente,ramTotal,ramDispo,usoCpu")] COMPONENTE cOMPONENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMPONENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cOMPONENTE);
        }

        // GET: Componentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPONENTE cOMPONENTE = db.COMPONENTE.Find(id);
            if (cOMPONENTE == null)
            {
                return HttpNotFound();
            }
            return View(cOMPONENTE);
        }

        // POST: Componentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COMPONENTE cOMPONENTE = db.COMPONENTE.Find(id);
            db.COMPONENTE.Remove(cOMPONENTE);
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
