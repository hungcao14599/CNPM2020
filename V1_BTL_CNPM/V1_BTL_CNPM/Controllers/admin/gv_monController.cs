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
    public class gv_monController : BaseController
    {
        private db_cnpm_v3Entities db = new db_cnpm_v3Entities();

        // GET: gv_mon
        public ActionResult Index()
        {
            var gv_mon = db.gv_mon.Include(g => g.giangvien).Include(g => g.giangvien1).Include(g => g.mon).Include(g => g.mon1);
            return View(gv_mon.ToList());
        }

        // GET: gv_mon/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gv_mon gv_mon = db.gv_mon.Find(id);
            if (gv_mon == null)
            {
                return HttpNotFound();
            }
            return View(gv_mon);
        }

        // GET: gv_mon/Create
        public ActionResult Create()
        {
            ViewBag.MaGV = new SelectList(db.giangviens, "MaGV", "HoTenGV");
            ViewBag.MaGV = new SelectList(db.giangviens, "MaGV", "HoTenGV");
            ViewBag.MaMon = new SelectList(db.mons, "MaMon", "TenMon");
            ViewBag.MaMon = new SelectList(db.mons, "MaMon", "TenMon");
            ViewBag.MaNganh = new SelectList(db.nganhs, "MaNganh", "TenNganh");
            return View();
        }

        // POST: gv_mon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        public bool CheckMaMon(string mamon)
        {
            return db.gv_mon.Count(x => x.MaMon == mamon) > 0;
        }


        [HttpPost]
        
        public ActionResult Create([Bind(Include = "MaGV,MaMon")] gv_mon gv_mon)
        {
            if (ModelState.IsValid)
            {
                if (CheckMaMon(gv_mon.MaMon))
                {
                    Response.Write("<script>alert('Giảng viên đã giảng dạy môn này')</script>");
                }
                else
                {
                    db.gv_mon.Add(gv_mon);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                    
                
            }

            ViewBag.MaGV = new SelectList(db.giangviens, "MaGV", "HoTenGV", gv_mon.MaGV);
            ViewBag.MaGV = new SelectList(db.giangviens, "MaGV", "HoTenGV", gv_mon.MaGV);
            ViewBag.MaMon = new SelectList(db.mons, "MaMon", "TenMon", gv_mon.MaMon);
            ViewBag.MaMon = new SelectList(db.mons, "MaMon", "TenMon", gv_mon.MaMon);
            ViewBag.MaNganh = new SelectList(db.nganhs, "MaNganh", "TenNganh");
            return View(gv_mon);
        }

        // GET: gv_mon/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gv_mon gv_mon = db.gv_mon.Find(id);
            if (gv_mon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGV = new SelectList(db.giangviens, "MaGV", "HoTenGV", gv_mon.MaGV);
            ViewBag.MaGV = new SelectList(db.giangviens, "MaGV", "HoTenGV", gv_mon.MaGV);
            ViewBag.MaMon = new SelectList(db.mons, "MaMon", "TenMon", gv_mon.MaMon);
            ViewBag.MaMon = new SelectList(db.mons, "MaMon", "TenMon", gv_mon.MaMon);
            ViewBag.MaNganh = new SelectList(db.nganhs, "MaNganh", "TenNganh");
            return View(gv_mon);
        }

        
        [HttpPost]
        
        public ActionResult Edit(gv_mon gv_mon)
        {
            if (ModelState.IsValid)
            {
                mon mon = new mon();
                db.Entry(mon).State = EntityState.Modified;
                db.SaveChanges();
                db.Entry(gv_mon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaGV = new SelectList(db.giangviens, "MaGV", "HoTenGV", gv_mon.MaGV);
            ViewBag.MaGV = new SelectList(db.giangviens, "MaGV", "HoTenGV", gv_mon.MaGV);
            ViewBag.MaMon = new SelectList(db.mons, "MaMon", "TenMon", gv_mon.MaMon);
            ViewBag.MaMon = new SelectList(db.mons, "MaMon", "TenMon", gv_mon.MaMon);

            ViewBag.MaNganh = new SelectList(db.nganhs, "MaNganh", "TenNganh");
            return View(gv_mon);
        }

        // GET: gv_mon/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gv_mon gv_mon = db.gv_mon.Find(id);
            if (gv_mon == null)
            {
                return HttpNotFound();
            }
            return View(gv_mon);
        }

        // POST: gv_mon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            gv_mon gv_mon = db.gv_mon.Find(id);
            db.gv_mon.Remove(gv_mon);
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
