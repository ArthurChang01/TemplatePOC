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
    [Table("ResellerUser")]
    public class ResellerUser:EntityBase<Guid>
    {
        [StringLength(8)]
        [Required()]
        [Column(TypeName = "varchar")]
        public string Code { get; set; }

        [StringLength(8)]
        [Required()]
        [Column(TypeName = "varchar")]
        public string UserName { get; set; }

        [StringLength(8)]
        [Required()]
        [Column(TypeName = "varchar")]
        public string Password { get; set; }
    }
}
