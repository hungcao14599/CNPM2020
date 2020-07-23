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
        private db_cnpm_v3Entities db = new db_cnpm_v3Entities();

        // GET: lichtrinhthuctes
        public ActionResult Index()
        {
            var lichtrinhthuctes = db.lichtrinhthuctes.Include(l => l.giangvien);
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

        public bool CheckMaLTTT(string malttt)
        {
            return db.lichtrinhthuctes.Count(x => x.MaLTTT == malttt) > 0;
        }


        public ActionResult Create()
        {
            ViewBag.MaGV = new SelectList(db.giangviens, "MaGV", "HoTenGV");
            return View();
        }

        
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLTTT,BaiHocTT,DiaDiemTT,ThoiGianTTBD,ThoiGianTTKT,MaGV")] lichtrinhthucte lichtrinhthucte)
        {
            if (ModelState.IsValid)
            {
                if (CheckMaLTTT(lichtrinhthucte.MaLTTT))
                {
                    Response.Write("<script>alert('Lịch trình thực tế này đã tồn tại')</script>");
                }
                else
                {
                    db.lichtrinhthuctes.Add(lichtrinhthucte);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }

            ViewBag.MaGV = new SelectList(db.giangviens, "MaGV", "HoTenGV", lichtrinhthucte.MaGV);
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
            return View(lichtrinhthucte);
        }

        // POST: lichtrinhthuctes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLTTT,BaiHocTT,DiaDiemTT,ThoiGianTTBD,ThoiGianTTKT,MaGV")] lichtrinhthucte lichtrinhthucte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lichtrinhthucte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaGV = new SelectList(db.giangviens, "MaGV", "HoTenGV", lichtrinhthucte.MaGV);
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
