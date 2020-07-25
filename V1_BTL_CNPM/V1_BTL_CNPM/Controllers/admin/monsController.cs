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
    public class monsController : BaseController
    {
        private db_cnpm_v3_1Entities db = new db_cnpm_v3_1Entities();

        // GET: mons
        public ActionResult Index()
        {
            var mons = db.mons.Include(m => m.nganh);
            return View(mons.ToList());
        }

        // GET: mons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mon mon = db.mons.Find(id);
            if (mon == null)
            {
                return HttpNotFound();
            }
            return View(mon);
        }

        // GET: mons/Create

        public bool CheckMaMon(string mamon)
        {
            return db.mons.Count(x => x.MaMon == mamon) > 0;
        }


        public ActionResult Create()
        {
            ViewBag.MaNganh = new SelectList(db.nganhs, "MaNganh", "TenNganh");
            return View();
        }

        
        [HttpPost]
        
        public ActionResult Create([Bind(Include = "MaMon,TenMon,MaNganh")] mon mon)
        {
            if (ModelState.IsValid)
            {
                if (CheckMaMon(mon.MaMon))
                {
                    Response.Write("<script>alert('Môn học này đã tồn tại')</script>");
                }
                else
                {
                    db.mons.Add(mon);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }

            ViewBag.MaNganh = new SelectList(db.nganhs, "MaNganh", "TenNganh", mon.MaNganh);
            return View(mon);
        }

        // GET: mons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mon mon = db.mons.Find(id);
            if (mon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNganh = new SelectList(db.nganhs, "MaNganh", "TenNganh", mon.MaNganh);
            return View(mon);
        }

        // POST: mons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMon,TenMon,MaNganh")] mon mon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNganh = new SelectList(db.nganhs, "MaNganh", "TenNganh", mon.MaNganh);
            return View(mon);
        }

        // GET: mons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mon mon = db.mons.Find(id);
            if (mon == null)
            {
                return HttpNotFound();
            }
            return View(mon);
        }

        // POST: mons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            mon mon = db.mons.Find(id);
            db.mons.Remove(mon);
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

        public ActionResult Search(string searchString)
        {
            var links = from l in db.mons
                        select l;

            if (!String.IsNullOrEmpty(searchString))
            {
                links = links.Where(s => s.TenMon.Contains(searchString));
            }

            return View(links);
        }


    }
}
