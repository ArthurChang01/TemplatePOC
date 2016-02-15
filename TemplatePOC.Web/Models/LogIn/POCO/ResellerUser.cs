using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TemplatePOC.Web.Models.LogIn.POCO
{
    [Table("ResellerUser")]
    public class ResellerUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(8)]
        [Required()]
        [Column(TypeName = "varchar")]
        public string Code { get; set; }

        [StringLength(8)]
        [Required()]
        [Column(TypeName ="varchar")]
        public string UserName { get; set; }

        [StringLength(8)]
        [Required()]
        [Column(TypeName = "varchar")]
        public string Password { get; set; }
    }
}