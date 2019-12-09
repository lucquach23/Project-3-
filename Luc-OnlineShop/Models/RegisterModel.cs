using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Luc_OnlineShop.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { get; set; }



        [Display(Name="Tên đăng nhập")]
        [Required(ErrorMessage ="Mời nhập tên đăng nhập")]
        public string UserName { set; get; }

        [Display(Name = "Mật khẩu")]
        [StringLength(20,MinimumLength =6,ErrorMessage ="Độ dài 6 kí tự trở lên")]
        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string Password { set; get; }


        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password",ErrorMessage ="Mật khẩu không trùng khớp")]
        public string  ConfirmPassword { get; set; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Mời nhập họ tên")]
        public string Name { set; get; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Mời nhập địa chỉ")]
        public string Address { set; get; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Mời nhập email")]
        public string Email { set; get; }


        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "Mời nhập số điện thoại")]
        public string Phone { set; get; }
    }
}