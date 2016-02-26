using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplatePOC.Core.Base;
using TemplatePOC.Core.Base.Element;
using TemplatePOC.Core.SubDomain.LobbyDomain.ValueObject;

namespace TemplatePOC.Core.SubDomain.LobbyDomain.Entity
{
    [Table("TemplateGameGroup")]
    public class TemplateGameGroup:EntityBase<Guid>
    {
        public TemplateGameGroup() {
            this.CreatedDate = DateTime.Now;
            this.UpdatedDate = DateTime.Now;
        }

        public TemplateGameGroupDescription Description { get; set; }

        [ForeignKey("Template")]
        public Guid TemplateId { get; set; }

        public virtual Template Template { get; set; }
    }
}
