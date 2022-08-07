﻿using System;
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

        public ActionResult GioHangPartial()
        {

            ViewBag.Total = Total();
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

    }
}   