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
    public class AdminDirectorateController : Controller
    {
        private WarAppDBContext db = new WarAppDBContext();

        // GET: AdminDirectorate
        public ActionResult Index()
        {
            return View(db.lutER_Directorate.ToList());
        }

        // GET: AdminDirectorate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Directorate lutER_Directorate = db.lutER_Directorate.Find(id);
            if (lutER_Directorate == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Directorate);
        }

        // GET: AdminDirectorate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminDirectorate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DirectorateId,DirectorateName")] lutER_Directorate lutER_Directorate)
        {
            if (ModelState.IsValid)
            {
                db.lutER_Directorate.Add(lutER_Directorate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lutER_Directorate);
        }

        // GET: AdminDirectorate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Directorate lutER_Directorate = db.lutER_Directorate.Find(id);
            if (lutER_Directorate == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Directorate);
        }

        // POST: AdminDirectorate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DirectorateId,DirectorateName")] lutER_Directorate lutER_Directorate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lutER_Directorate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lutER_Directorate);
        }

        // GET: AdminDirectorate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Directorate lutER_Directorate = db.lutER_Directorate.Find(id);
            if (lutER_Directorate == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Directorate);
        }

        // POST: AdminDirectorate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lutER_Directorate lutER_Directorate = db.lutER_Directorate.Find(id);
            db.lutER_Directorate.Remove(lutER_Directorate);
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
