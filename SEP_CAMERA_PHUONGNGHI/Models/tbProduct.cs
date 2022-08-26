//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SEP_CAMERA_PHUONGNGHI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tbProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbProduct()
        {
            this.KhoHangs = new HashSet<KhoHang>();
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        public int product_id { get; set; }
        [StringLength(250, MinimumLength = 1)]
        public string Name { get; set; }
        [StringLength(250, MinimumLength = 1)]

        public string SeoTitle { get; set; }
        public Nullable<bool> Status { get; set; }
        public string Thumnail { get; set; }
        [Required]
        public Nullable<int> Price { get; set; }
        [Required]
        public Nullable<int> PromotionPrice { get; set; }
        [Required]
        public string TonKho { get; set; }
        [Required]
        public Nullable<int> BaoHanh { get; set; }
        [StringLength(1000, MinimumLength = 1)]
        public string Desciption { get; set; }
        public Nullable<int> category_id { get; set; }
        public Nullable<int> brand_id { get; set; }
        public string MetaKey { get; set; }
        public string MetaDescription { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> rank { get; set; }
        public Nullable<int> comment_id { get; set; }
        [StringLength(50, MinimumLength = 1)]

        public string CambienAnh { get; set; }
        [StringLength(50, MinimumLength = 1)]

        public string Dophangiai { get; set; }
        [StringLength(50, MinimumLength = 1)]

        public string Ongkinh { get; set; }
        [StringLength(50, MinimumLength = 1)]

        public string Gocnhin { get; set; }
        [StringLength(50, MinimumLength = 1)]

        public string ChuannenVideo { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual CommentProduct CommentProduct { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoHang> KhoHangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
