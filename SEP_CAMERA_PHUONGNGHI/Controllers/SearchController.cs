using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEP_CAMERA_PHUONGNGHI.Models;
using PagedList;
using PagedList.Mvc;

namespace SEP_CAMERA_PHUONGNGHI.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        SEP25Team01Entities db = new SEP25Team01Entities();
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f, int? page)
        {
            string sKeyword = f["txtSearch"].ToString();
            List<tbProduct> ketQuaTK = db.tbProducts.Where(x => x.Name.Contains(sKeyword)).ToList();
            //phantrang
            int pageNumber = (page ?? 1);
            int pageSize = 9;

            if (ketQuaTK.Count == 0)
            {
                ViewBag.Thongbao = "Không tìm thấy sản phẩm nào";
                return View(db.tbProducts.OrderBy(x => x.Name).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.Thongbao = "Đã tìm thấy" + ketQuaTK.Count + "Kết quả";
            return View(ketQuaTK.OrderBy(x => x.Name).ToPagedList(pageNumber, pageSize));
        }
    }
}