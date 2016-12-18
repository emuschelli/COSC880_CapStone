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
    public class AdminOrganizationController : Controller
    {
        private WarAppDBContext db = new WarAppDBContext();

        // GET: AdminOrganization
        public ActionResult Index()
        {
            return View(db.lutER_Organization.ToList());
        }

        // GET: AdminOrganization/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Organization lutER_Organization = db.lutER_Organization.Find(id);
            if (lutER_Organization == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Organization);
        }

        // GET: AdminOrganization/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminOrganization/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrganizationalId,OrganizationalName")] lutER_Organization lutER_Organization)
        {
            if (ModelState.IsValid)
            {
                db.lutER_Organization.Add(lutER_Organization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lutER_Organization);
        }

        // GET: AdminOrganization/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Organization lutER_Organization = db.lutER_Organization.Find(id);
            if (lutER_Organization == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Organization);
        }

        // POST: AdminOrganization/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrganizationalId,OrganizationalName")] lutER_Organization lutER_Organization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lutER_Organization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lutER_Organization);
        }

        // GET: AdminOrganization/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Organization lutER_Organization = db.lutER_Organization.Find(id);
            if (lutER_Organization == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Organization);
        }

        // POST: AdminOrganization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lutER_Organization lutER_Organization = db.lutER_Organization.Find(id);
            db.lutER_Organization.Remove(lutER_Organization);
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
