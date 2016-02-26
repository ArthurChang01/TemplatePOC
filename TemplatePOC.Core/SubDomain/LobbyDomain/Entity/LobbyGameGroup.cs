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
    [Table("LobbyGameGroup")]
    public class LobbyGameGroup:EntityBase<Guid>
    {
        public LobbyGameGroup() {
            this.CreatedDate = DateTime.Now;
            this.UpdatedDate = DateTime.Now;
        }

        public LobbyGameGroupDescription Description { get; set; }

        [ForeignKey("Lobby")]
        public Guid LobbyId { get; set; }

        public virtual Lobby Lobby { get; set; }
    }
}
