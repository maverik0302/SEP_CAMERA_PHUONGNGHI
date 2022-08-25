using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SEP_CAMERA_PHUONGNGHI.Models;

namespace SEP_CAMERA_PHUONGNGHI.Models
{
    public class GioHang
    {
        SEP25Team01Entities db = new SEP25Team01Entities();


        public int iMaProduct { get; set; }
        public string sName { get; set; }
        public string sThumbnail { get; set; }
        public int sPrice { get; set; }
        public int sPricePromotion { get; set; }
        public int sAmount { get; set; }

        public int deviant
        {
            get { return sPrice - sPricePromotion; }
        }
        public int ThanhTien
        {
            get { return (sAmount * sPrice)- (sAmount * deviant); }
        }

        

        

        public GioHang(int MaProduct)
        {
            iMaProduct = MaProduct;
            tbProduct prod = db.tbProducts.Single(n => n.product_id == iMaProduct);
            sName = prod.Name;
            sThumbnail = prod.Thumnail;
            sPrice = (int)prod.Price;
            sPricePromotion = (int)prod.PromotionPrice;
            sAmount = 1;

        }

    }
}