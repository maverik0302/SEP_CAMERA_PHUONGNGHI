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

    public partial class About
    {
        public int about_id { get; set; }
        [StringLength(250, MinimumLength = 1)]
        public string Title { get; set; }
        [StringLength(1000, MinimumLength = 1)]
        public string Description { get; set; }
        public string Owner { get; set; }
        public string MetaKey { get; set; }
        public string MetaDescription { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}
