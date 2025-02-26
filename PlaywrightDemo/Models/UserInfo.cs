using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PlaywrightDemo.Models
{
	public class UserInfo
	{
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "姓名不能為空")]
        public string Name { get; set; }

        [Display(Name = "電子郵件")]
        [Required(ErrorMessage = "電子郵件不能為空")]
        [EmailAddress(ErrorMessage = "電子郵件格式錯誤")]
        public string Email { get; set; }
    }
}