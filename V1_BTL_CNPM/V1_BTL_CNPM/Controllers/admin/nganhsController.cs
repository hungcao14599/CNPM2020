using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using V1_BTL_CNPM.Controllers.admin;
using V1_BTL_CNPM.Models;

namespace V1_BTL_CNPM.Controllers
{
    public class nganhsController : BaseController
    {
        private db_cnpm_v3Entities db = new db_cnpm_v3Entities();

        // GET: nganhs
        public ActionResult Index()
        {
            var nganhs = db.nganhs.Include(n => n.khoa);
            return View(nganhs.ToList());
        }

       

        // GET: nganhs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nganh nganh = db.nganhs.Find(id);
            if (nganh == null)
            {
                return HttpNotFound();
            }
            return View(nganh);
        }

        // GET: nganhs/Create
        public ActionResult Create()
        {
            ViewBag.MaKhoa = new SelectList(db.khoas, "MaKhoa", "TenKhoa");
            return View();
        }

        // POST: nganhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNganh,TenNganh,MaKhoa")] nganh nganh)
        {
            if (ModelState.IsValid)
            {
                db.nganhs.Add(nganh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhoa = new SelectList(db.khoas, "MaKhoa", "TenKhoa", nganh.MaKhoa);
            return View(nganh);
        }

        // GET: nganhs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nganh nganh = db.nganhs.Find(id);
            if (nganh == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhoa = new SelectList(db.khoas, "MaKhoa", "TenKhoa", nganh.MaKhoa);
            return View(nganh);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNganh,TenNganh,MaKhoa")] nganh nganh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nganh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhoa = new SelectList(db.khoas, "MaKhoa", "TenKhoa", nganh.MaKhoa);
            return View(nganh);
        }

        // GET: nganhs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nganh nganh = db.nganhs.Find(id);
            if (nganh == null)
            {
                return HttpNotFound();
            }
            return View(nganh);
        }

        // POST: nganhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            nganh nganh = db.nganhs.Find(id);
            db.nganhs.Remove(nganh);
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
