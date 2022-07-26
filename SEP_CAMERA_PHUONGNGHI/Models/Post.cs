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


    public partial class Post
    {
        public int post_id { get; set; }
        public string Name { get; set; }
        [StringLength(1000, MinimumLength = 1)]
        public string SeoTitle { get; set; }
        public Nullable<bool> Status { get; set; }
        public string Image { get; set; }
        [StringLength(1000, MinimumLength = 1)]
        public string Description { get; set; }
        public string Detail { get; set; }
        public string MetaKey { get; set; }
        public string MetaDescription { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> comment_id { get; set; }
    
        public virtual CommentPost CommentPost { get; set; }
    }
}
