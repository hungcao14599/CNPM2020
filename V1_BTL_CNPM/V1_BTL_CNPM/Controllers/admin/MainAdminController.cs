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

        private db_cnpm_v3Entities db = new db_cnpm_v3Entities();
        // GET: MainAdmin
        public ActionResult Index()
        {

            var query = db.nganhs.Where(x => x.MaNganh != string.Empty);
            int count = query.Count();
            ViewBag.ListCount = count;
            return View(query.ToList());


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