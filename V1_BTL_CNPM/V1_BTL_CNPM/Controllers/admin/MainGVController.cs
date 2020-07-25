using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V1_BTL_CNPM.Models;

namespace V1_BTL_CNPM.Controllers.admin
{
    public class MainGVController : Controller
    {
        // GET: MainGV


        private db_cnpm_v3_1Entities db = new db_cnpm_v3_1Entities();
        public ActionResult Index()
        {

            return View(db);
        }
    }
}