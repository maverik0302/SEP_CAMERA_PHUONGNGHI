using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEP_CAMERA_PHUONGNGHI.Models;

namespace SEP_CAMERA_PHUONGNGHI.Controllers
{
    public class HistoryController : Controller
    {
        SEP25Team01Entities db = new SEP25Team01Entities();
        // GET: History
        public ActionResult History()
        {
            
                


            List<Oder> YourOder = db.Oders.ToList();
            
            return View(YourOder);
        }
    }
}