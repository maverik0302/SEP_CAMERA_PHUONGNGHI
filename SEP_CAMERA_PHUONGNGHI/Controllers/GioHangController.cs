using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEP_CAMERA_PHUONGNGHI.Models;

namespace SEP_CAMERA_PHUONGNGHI.Controllers
{
    public class GioHangController : Controller
    {
        SEP25Team01Entities db = new SEP25Team01Entities();
        #region
        // GET: Cart
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstCart = Session["GioHang"] as List<GioHang>;
            if (lstCart == null)
            {
                lstCart = new List<GioHang>();
                Session["GioHang"] = lstCart;
            }
            return lstCart;
        }

        //add cart
        public ActionResult ThemGioHang(int iMaProduct, string strUrl)
        {
            tbProduct prod = db.tbProducts.SingleOrDefault(n => n.product_id == iMaProduct);
            if (prod == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            List<GioHang> lstCart = LayGioHang();
            GioHang sp = lstCart.Find(n => n.iMaProduct == iMaProduct);
            if (sp == null)
            {
                sp = new GioHang(iMaProduct);
                //add sản phẩm
                lstCart.Add(sp);
                return Redirect(strUrl);
            }
            else
            {
                sp.sAmount++;
                return Redirect(strUrl);
            }
        }

        //update cart
        public ActionResult CapNhatGioHang(int iMa, FormCollection f)
        {
            //Check ID Product
            tbProduct prod = db.tbProducts.SingleOrDefault(n => n.product_id == iMa);
            //if get wrong product, response error code
            if (prod == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //get cart from session
            List<GioHang> lstCart = LayGioHang();
            //Check if the product exists
            GioHang sp = lstCart.SingleOrDefault(n => n.iMaProduct == iMa);
            if (sp != null)
            {
                sp.sAmount = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang");

        }

        //Delete item in cart
        public ActionResult Xoagiohang(int iMa)
        {
            tbProduct prod = db.tbProducts.SingleOrDefault(n => n.product_id == iMa);
            if (prod == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //get cart
            List<GioHang> lstCart = LayGioHang();
            //Check if the product exists
            GioHang sp = lstCart.SingleOrDefault(n => n.iMaProduct == iMa);

            if (lstCart != null)
            {
                lstCart.RemoveAll(n => n.iMaProduct == iMa);
                return RedirectToAction("GioHang");
            }
            if (lstCart.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }

        //built cart
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstCart = LayGioHang();
            ViewBag.TongTien = TongTien();
            return View(lstCart);

        }

        //caculate amout n price
        private int Total()
        {
            int iTotal = 0;
            List<GioHang> lstCart = Session["GioHang"] as List<GioHang>;
            if (lstCart != null)
            {
                iTotal = lstCart.Sum(n => n.sAmount);

            }
            return iTotal;
        }

        private int TongTien()
        {
            int dTongTien = 0;
            List<GioHang> lstCart = Session["GioHang"] as List<GioHang>;
            if (lstCart != null)
            {
                dTongTien = lstCart.Sum(n => n.ThanhTien);
            }
            return dTongTien;
        }

        private int sDiviant()
        {
            int km = 0;
            List<GioHang> lstCart = Session["GioHang"] as List<GioHang>;
            if (lstCart != null)
            {
                km = lstCart.Sum(n => n.deviant);
            }
            return km;

        }


        public ActionResult GioHangPartial()
        {
            
            ViewBag.Total = Total();
            ViewBag.TongTien = TongTien();
            return PartialView();

        }

        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstCart = LayGioHang();
            return View(lstCart);
        }
        #endregion


        #region Đặt Hàng    
        [HttpGet]

        public ActionResult DatHang()
        {
            if (Session["Account"] == null || Session["Account"].ToString() == "")
            {
                ViewBag.Message = "Vui lòng đăng nhập";
                return RedirectToAction("Login", "Auth", new { area = "Admin" });
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //get cart
            List<GioHang> lstCart = LayGioHang();


            ViewBag.Total = Total();
            ViewBag.TongTien = TongTien();
            ViewBag.sDiviant = sDiviant();
            return View(lstCart);
        }

        [HttpPost]            
        
        public ActionResult DatHang(FormCollection f)
        {
            CUSTOMER customer = new CUSTOMER();
            db.CUSTOMERs.Add(customer);
            db.SaveChanges();

            Oder donhang = new Oder();
            
            List<GioHang> lstCart = LayGioHang();
            donhang.customer_id = customer.customer_id;
            donhang.orderdate = DateTime.Now;
            donhang.Delivered = false;
            donhang.Status = true;
            donhang.total_price = TongTien();
            db.Oders.Add(donhang);
            db.SaveChanges();
            foreach (var item in lstCart)
            {
                OrderDetail detail = new OrderDetail();
                detail.product_id = item.iMaProduct;
                detail.num = item.sAmount;
                detail.price_product = (int)item.sPrice;
                db.OrderDetails.Add(detail);
            }
            db.SaveChanges();
            Session["GioHang"] = null;
            return RedirectToAction("XacNhanDonHang", "GioHang");
        }
        public ActionResult XacNhanDonHang()
        {
            return View();
        }


        #endregion
    }
}   