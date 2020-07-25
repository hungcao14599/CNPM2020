using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V1_BTL_CNPM.Models;

namespace V1_BTL_CNPM.Controllers.admin
{
    public class MainAdminController : BaseController
    {

        private db_cnpm_v3_1Entities db = new db_cnpm_v3_1Entities();
        // GET: MainAdmin
        public ActionResult Index()
        {

            /*var query = db.nganhs.Where(x => x.MaNganh != string.Empty);
            int count = query.Count();
            ViewBag.ListCount = count;

            //var query1 = db.khoas.Where(x => x.MaNganh != string.Empty);
            //int count = query.Count();
            ViewBag.ListCount = count;


            //return View(new {a = query.ToList(), b =  });*/
            return View(db);


        }

        public ActionResult CountNganh()
        {
            var query = db.nganhs.Where(x => x.MaNganh != string.Empty);
            int count = query.Count();
            ViewBag.ListCount = count;
            return View(query.ToList());
        }
    }
}