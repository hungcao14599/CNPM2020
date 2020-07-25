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
    public class khoasController : BaseController
    {
        private db_cnpm_v3_1Entities db = new db_cnpm_v3_1Entities();

        // GET: khoas
        public ActionResult Khoa()
        {
            return View(db.khoas.ToList());
        }

        // GET: khoas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            khoa khoa = db.khoas.Find(id);
            if (khoa == null)
            {
                return HttpNotFound();
            }
            return View(khoa);
        }

        // GET: khoas/Create

        public bool CheckMaKhoa(string makhoa)
        {
            return db.khoas.Count(x => x.MaKhoa == makhoa) > 0;
        }


        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]

        public ActionResult Create(khoa khoa)
        {
            if (ModelState.IsValid)
            {
                if (CheckMaKhoa(khoa.MaKhoa))
                {
                    Response.Write("<script>alert('Khoa này đã tồn tại')</script>");
                }
                else
                {
                    db.khoas.Add(khoa);
                    db.SaveChanges();
                    return RedirectToAction("Khoa");
                }
                
            }

            return View(khoa);
        }

        // GET: khoas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            khoa khoa = db.khoas.Find(id);
            if (khoa == null)
            {
                return HttpNotFound();
            }
            return View(khoa);
        }

        // POST: khoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see 
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenKhoa,MaKhoa")] khoa khoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Khoa");
            }
            return View(khoa);
        }

        // GET: khoas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            khoa khoa = db.khoas.Find(id);
            if (khoa == null)
            {
                return HttpNotFound();
            }
            return View(khoa);
        }

        // POST: khoas/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            khoa khoa = db.khoas.Find(id);
            db.khoas.Remove(khoa);
            db.SaveChanges();
            return RedirectToAction("Khoa");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]

        public ActionResult Search(string searchString)
        {
            var links = from l in db.khoas
                        select l;

            if (!String.IsNullOrEmpty(searchString))
            {
                links = links.Where(s => s.TenKhoa.Contains(searchString));
            }

            return View(links);
        }

    }
}
