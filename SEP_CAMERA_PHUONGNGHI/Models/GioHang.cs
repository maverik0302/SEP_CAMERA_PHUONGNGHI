using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SEP_CAMERA_PHUONGNGHI.Models;

namespace SEP_CAMERA_PHUONGNGHI.Models
{
    public class GioHang
    {
        //private int _idProduct;

        //public int IdProduct { get => _idProduct; set => _idProduct = value; }
        SEP25Team01Entities db = new SEP25Team01Entities();
        public int iProduct { get; set; }
        public string sNameProduct { get; set; }
        public string sThumbnail { get; set; }
        public int sDongia { get; set; }
        public int sAmount { get; set; }
        public int sThanhTien
        {
            get { return sAmount * sDongia; }
        }
        public GioHang(int idProduct)
        {
            iProduct = idProduct;
            tbProduct sanpham = db.tbProducts.Single(n => n.product_id == iProduct);
            sNameProduct = sanpham.Name;
            sThumbnail = sanpham.Thumnail;
            sDongia = (int)sanpham.Price;
            sAmount = 1;
        }
    }
}