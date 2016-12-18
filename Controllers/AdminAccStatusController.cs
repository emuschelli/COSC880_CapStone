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
    public class AdminAccStatusController : Controller
    {
        
        private WarAppDBContext db = new WarAppDBContext();

        // GET: AdminAccStatus
       public ActionResult Index()
        {
            return View(db.lutWAR_AccStatus.ToList());
        }

        // GET: AdminAccStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutWAR_AccStatus lutWAR_AccStatus = db.lutWAR_AccStatus.Find(id);
            if (lutWAR_AccStatus == null)
            {
                return HttpNotFound();
            }
            return View(lutWAR_AccStatus);
        }

        // GET: AdminAccStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminAccStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccStatusId,Status")] lutWAR_AccStatus lutWAR_AccStatus)
        {
            if (ModelState.IsValid)
            {
                db.lutWAR_AccStatus.Add(lutWAR_AccStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lutWAR_AccStatus);
        }

        // GET: AdminAccStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutWAR_AccStatus lutWAR_AccStatus = db.lutWAR_AccStatus.Find(id);
            if (lutWAR_AccStatus == null)
            {
                return HttpNotFound();
            }
            return View(lutWAR_AccStatus);
        }

        // POST: AdminAccStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccStatusId,Status")] lutWAR_AccStatus lutWAR_AccStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lutWAR_AccStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lutWAR_AccStatus);
        }

        // GET: AdminAccStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutWAR_AccStatus lutWAR_AccStatus = db.lutWAR_AccStatus.Find(id);
            if (lutWAR_AccStatus == null)
            {
                return HttpNotFound();
            }
            return View(lutWAR_AccStatus);
        }

        // POST: AdminAccStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lutWAR_AccStatus lutWAR_AccStatus = db.lutWAR_AccStatus.Find(id);
            db.lutWAR_AccStatus.Remove(lutWAR_AccStatus);
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
