using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TemplatePOC.Web.Models.LogIn.POCO
{
    [Table("AdminUser")]
    public class AdminUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(5)]
        [Required()]
        [Column(TypeName = "varchar")]
        public string UserName { get; set; }

        [StringLength(5)]
        [Required()]
        [Column(TypeName = "varchar")]
        public string Password { get; set; }
    }
}