using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using V1_BTL_CNPM.Models;

namespace V1_BTL_CNPM.Controllers.admin
{
    public class thoigianhocsController : Controller
    {
        private db_cnpm_v2Entities db = new db_cnpm_v2Entities();

        // GET: thoigianhocs
        public ActionResult Index()
        {
            return View(db.thoigianhocs.ToList());
        }

        // GET: thoigianhocs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thoigianhoc thoigianhoc = db.thoigianhocs.Find(id);
            if (thoigianhoc == null)
            {
                return HttpNotFound();
            }
            return View(thoigianhoc);
        }

        // GET: thoigianhocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: thoigianhocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NamHoc,HocKy,GiaiDoan,MaTGH")] thoigianhoc thoigianhoc)
        {
            if (ModelState.IsValid)
            {
                db.thoigianhocs.Add(thoigianhoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thoigianhoc);
        }

        // GET: thoigianhocs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thoigianhoc thoigianhoc = db.thoigianhocs.Find(id);
            if (thoigianhoc == null)
            {
                return HttpNotFound();
            }
            return View(thoigianhoc);
        }

        // POST: thoigianhocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NamHoc,HocKy,GiaiDoan,MaTGH")] thoigianhoc thoigianhoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thoigianhoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thoigianhoc);
        }

        // GET: thoigianhocs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thoigianhoc thoigianhoc = db.thoigianhocs.Find(id);
            if (thoigianhoc == null)
            {
                return HttpNotFound();
            }
            return View(thoigianhoc);
        }

        // POST: thoigianhocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            thoigianhoc thoigianhoc = db.thoigianhocs.Find(id);
            db.thoigianhocs.Remove(thoigianhoc);
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
