using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V1_BTL_CNPM.Models;

namespace V1_BTL_CNPM.Controllers.admin
{
    public class MainAdminController : Controller
    {

        private db_cnpm_v2Entities db = new db_cnpm_v2Entities();
        // GET: MainAdmin
        public ActionResult Index()
        {

            return View();
        }
    }
}