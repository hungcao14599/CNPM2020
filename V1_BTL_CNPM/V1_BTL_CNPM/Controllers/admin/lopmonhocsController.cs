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
    public class lopmonhocsController : BaseController
    {
        private db_cnpm_v3Entities db = new db_cnpm_v3Entities();

        // GET: lopmonhocs
        public ActionResult Index()
        {
            var lopmonhocs = db.lopmonhocs.Include(l => l.mon);
            return View(lopmonhocs.ToList());
        }

        // GET: lopmonhocs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lopmonhoc lopmonhoc = db.lopmonhocs.Find(id);
            if (lopmonhoc == null)
            {
                return HttpNotFound();
            }
            return View(lopmonhoc);
        }

        // GET: lopmonhocs/Create
        public ActionResult Create()
        {
            ViewBag.MaMon = new SelectList(db.mons, "MaMon", "TenMon");
            return View();
        }

        // POST: lopmonhocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLTM,TenLopMon,MaMon")] lopmonhoc lopmonhoc)
        {
            if (ModelState.IsValid)
            {
                db.lopmonhocs.Add(lopmonhoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaMon = new SelectList(db.mons, "MaMon", "TenMon", lopmonhoc.MaMon);
            return View(lopmonhoc);
        }

        // GET: lopmonhocs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lopmonhoc lopmonhoc = db.lopmonhocs.Find(id);
            if (lopmonhoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMon = new SelectList(db.mons, "MaMon", "TenMon", lopmonhoc.MaMon);
            return View(lopmonhoc);
        }

        // POST: lopmonhocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLTM,TenLopMon,MaMon")] lopmonhoc lopmonhoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lopmonhoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaMon = new SelectList(db.mons, "MaMon", "TenMon", lopmonhoc.MaMon);
            return View(lopmonhoc);
        }

        // GET: lopmonhocs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lopmonhoc lopmonhoc = db.lopmonhocs.Find(id);
            if (lopmonhoc == null)
            {
                return HttpNotFound();
            }
            return View(lopmonhoc);
        }

        // POST: lopmonhocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            lopmonhoc lopmonhoc = db.lopmonhocs.Find(id);
            db.lopmonhocs.Remove(lopmonhoc);
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
