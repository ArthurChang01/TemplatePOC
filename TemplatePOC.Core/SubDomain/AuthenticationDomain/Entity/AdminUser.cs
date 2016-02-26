using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplatePOC.Core.Base.Element;

namespace TemplatePOC.Core.SubDomain.AuthenticationDomain.Entity
{
    [Table("AdminUser")]
    public class AdminUser : EntityBase<Guid>
    {
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
