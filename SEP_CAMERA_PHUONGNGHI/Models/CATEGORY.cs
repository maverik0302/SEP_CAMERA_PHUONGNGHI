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
    
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            this.tbProduct = new HashSet<tbProduct>();
        }
    
        public int category_id { get; set; }
        public string Name { get; set; }
        public string SeoTitle { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> sort { get; set; }
        public Nullable<int> ParentID { get; set; }
        public string MetaKey { get; set; }
        public string MetaDescription { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbProduct> tbProduct { get; set; }
    }
}
