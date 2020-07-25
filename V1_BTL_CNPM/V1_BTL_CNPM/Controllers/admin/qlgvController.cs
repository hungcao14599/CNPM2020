using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V1_BTL_CNPM.Models;


namespace V1_BTL_CNPM.Controllers.admin
{
    public class qlgvController : BaseController
    {
        // GET: qlgv

        private db_cnpm_v3_1Entities db = new db_cnpm_v3_1Entities();

        public ActionResult qlgv()
        {
            var user = from a in db.taikhoans
                       join b in db.giangviens
                       on a.MaTK equals b.MaTK

                       select new qlgv()
                       {
                           
                           MaTK = a.MaTK,
                           MaGV = b.MaGV,
                           HoTenGV = b.HoTenGV,
                           MaKhoa = b.MaNganh,
                           NgaySinh = b.NgaySinh,
                           DiaChi = b.DiaChi,
                           SoDienThoai = b.SoDienThoai,
                           Email = b.Email,
            
                       };
            return View(user);
            //return View(db.giangviens.ToList());
        }

  

        
    }
}