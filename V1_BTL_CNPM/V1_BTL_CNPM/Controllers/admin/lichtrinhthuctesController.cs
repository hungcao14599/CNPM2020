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
    public class lichtrinhthuctesController : Controller
    {
        private db_cnpm_v3_1Entities db = new db_cnpm_v3_1Entities();

        // GET: lichtrinhthuctes
        public ActionResult Index()
        {
            var lichtrinhthuctes = db.lichtrinhthuctes.Include(l => l.giangvien).Include(l => l.mon);
            return View(lichtrinhthuctes.ToList());
        }

        // GET: lichtrinhthuctes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lichtrinhthucte lichtrinhthucte = db.lichtrinhthuctes.Find(id);
            if (lichtrinhthucte == null)
            {
                return HttpNotFound();
            }
            return View(lichtrinhthucte);
        }

        // GET: lichtrinhthuctes/Create
        public ActionResult Create()
        {
            ViewBag.MaGV = new SelectList(db.giangviens, "MaGV", "HoTenGV");
            ViewBag.MaMon = new SelectList(db.mons, "MaMon", "TenMon");
            return View();
        }

        // POST: lichtrinhthuctes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLTTT,MaMon,DiaDiemTT,ThoiGianTTBD,ThoiGianTTKT,MaGV")] lichtrinhthucte lichtrinhthucte)
        {
            if (ModelState.IsValid)
            {
                db.lichtrinhthuctes.Add(lichtrinhthucte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaGV = new SelectList(db.giangviens, "MaGV", "HoTenGV", lichtrinhthucte.MaGV);
            ViewBag.MaMon = new SelectList(db.mons, "MaMon", "TenMon", lichtrinhthucte.MaMon);
            return View(lichtrinhthucte);
        }

        // GET: lichtrinhthuctes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lichtrinhthucte lichtrinhthucte = db.lichtrinhthuctes.Find(id);
            if (lichtrinhthucte == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGV = new SelectList(db.giangviens, "MaGV", "HoTenGV", lichtrinhthucte.MaGV);
            ViewBag.MaMon = new SelectList(db.mons, "MaMon", "TenMon", lichtrinhthucte.MaMon);
            return View(lichtrinhthucte);
        }

        // POST: lichtrinhthuctes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLTTT,MaMon,DiaDiemTT,ThoiGianTTBD,ThoiGianTTKT,MaGV")] lichtrinhthucte lichtrinhthucte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lichtrinhthucte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaGV = new SelectList(db.giangviens, "MaGV", "HoTenGV", lichtrinhthucte.MaGV);
            ViewBag.MaMon = new SelectList(db.mons, "MaMon", "TenMon", lichtrinhthucte.MaMon);
            return View(lichtrinhthucte);
        }

        // GET: lichtrinhthuctes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lichtrinhthucte lichtrinhthucte = db.lichtrinhthuctes.Find(id);
            if (lichtrinhthucte == null)
            {
                return HttpNotFound();
            }
            return View(lichtrinhthucte);
        }

        // POST: lichtrinhthuctes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            lichtrinhthucte lichtrinhthucte = db.lichtrinhthuctes.Find(id);
            db.lichtrinhthuctes.Remove(lichtrinhthucte);
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
