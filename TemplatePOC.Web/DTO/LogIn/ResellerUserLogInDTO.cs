using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TemplatePOC.Web.DTO.LogIn
{
    public class ResellerUserLogInDTO
    {
        [Display(Name = "Code")]
        [Required, MinLength(8)]
        [DataType(DataType.Text)]
        public string Code { get; set; }

        [Display(Name = "UserName")]
        [Required,MinLength(8)]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required,MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}