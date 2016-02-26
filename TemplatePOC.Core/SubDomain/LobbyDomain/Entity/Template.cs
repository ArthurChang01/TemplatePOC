using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplatePOC.Core.Base;
using TemplatePOC.Core.Base.Element;
using TemplatePOC.Core.SubDomain.LobbyDomain.Enums;
using TemplatePOC.Core.SubDomain.LobbyDomain.ValueObject;

namespace TemplatePOC.Core.SubDomain.LobbyDomain.Entity
{
    [Table("Template")]
    public class Template:EntityBase<Guid>
    {
        public Template() {
            this.CreatedDate = DateTime.Now;
            this.UpdatedDate = DateTime.Now;
            this.Description.Status = enLobbyStatus.Activate;
            this.Description.Type = enLobbyType.Desktop;
        }

        public TemplateDescription Description { get; set; }

        public virtual ICollection<TemplateGameGroup> GameGroups { get; set; }

        public virtual ICollection<Lobby> Lobbies { get; set; }
    }
}
