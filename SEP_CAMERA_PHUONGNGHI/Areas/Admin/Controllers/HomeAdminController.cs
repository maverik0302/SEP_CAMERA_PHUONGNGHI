using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SEP_CAMERA_PHUONGNGHI.Areas.Admin.Middleware;
using System.Web.Mvc;

namespace SEP_CAMERA_PHUONGNGHI.Areas.Admin.Controllers
{
    [LoginVerification]
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}