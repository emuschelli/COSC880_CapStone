using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WarApp.Models;

namespace WarApp.Controllers
{
    [Authorize(Roles = "Admin")] //PREVENTS ANONYMOUS ACCESS
    public class AdminProjectsController : Controller
    {
        private WarAppDBContext db = new WarAppDBContext();

        // GET: AdminProjects
        public ActionResult Index()
        {
            return View(db.lutWAR_Projects.ToList());
        }

        // GET: AdminProjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutWAR_Projects lutWAR_Projects = db.lutWAR_Projects.Find(id);
            if (lutWAR_Projects == null)
            {
                return HttpNotFound();
            }
            return View(lutWAR_Projects);
        }

        // GET: AdminProjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjId,ProjectName")] lutWAR_Projects lutWAR_Projects)
        {
            if (ModelState.IsValid)
            {
                db.lutWAR_Projects.Add(lutWAR_Projects);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lutWAR_Projects);
        }

        // GET: AdminProjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutWAR_Projects lutWAR_Projects = db.lutWAR_Projects.Find(id);
            if (lutWAR_Projects == null)
            {
                return HttpNotFound();
            }
            return View(lutWAR_Projects);
        }

        // POST: AdminProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjId,ProjectName")] lutWAR_Projects lutWAR_Projects)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lutWAR_Projects).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lutWAR_Projects);
        }

        // GET: AdminProjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutWAR_Projects lutWAR_Projects = db.lutWAR_Projects.Find(id);
            if (lutWAR_Projects == null)
            {
                return HttpNotFound();
            }
            return View(lutWAR_Projects);
        }

        // POST: AdminProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lutWAR_Projects lutWAR_Projects = db.lutWAR_Projects.Find(id);
            db.lutWAR_Projects.Remove(lutWAR_Projects);
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
