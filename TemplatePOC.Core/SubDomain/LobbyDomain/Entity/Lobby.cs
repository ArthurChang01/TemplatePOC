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
    [Table("Lobby")]
    public class Lobby:EntityBase<Guid>
    {
        public Lobby() {
            this.CreatedDate = DateTime.Now;
            this.UpdatedDate = DateTime.Now;
            this.Description.Status = enLobbyStatus.Activate;
            this.Description.Type = enLobbyType.Desktop;
        }

        public LobbyDescription Description { get; set; }

        public virtual ICollection<LobbyGameGroup> LobbyGameGroups { get; set; } 

        public virtual ICollection<Template> Templates { get; set; }

        public void AddLobby(Lobby lobby)
        {

        }

        public void UpdateLobby(Lobby lobby)
        {
        }

        public void RemoveLobby(Lobby lobby)
        {
        }

    }
}
