using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TemplatePOC.Web.DTO.LogIn
{
    public class AdminUserLoginDTO
    {
        [Display(Name = "UserName")]
        [Required, MinLength(5)]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required, MinLength(5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}