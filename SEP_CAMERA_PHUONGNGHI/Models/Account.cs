﻿//------------------------------------------------------------------------------
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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;


    public partial class Account
    {
        public int user_id { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập tên người dùng")]
        [StringLength(50, MinimumLength = 1)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Vui lòng mật khẩu")]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ email")]
        [StringLength(50, MinimumLength = 1)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        [StringLength(50, MinimumLength = 1)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập họ")]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }
        public string Role { get; set; }
        public Nullable<bool> status { get; set; }
    }
}
