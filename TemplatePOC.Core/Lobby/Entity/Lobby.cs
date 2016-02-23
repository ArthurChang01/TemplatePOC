using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplatePOC.Core.Lobby.ValueObject;

namespace TemplatePOC.Core.Lobby.Entity
{
    public class Lobby
    {
        public Guid Id { get; set; }

        public LobbyDescription Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<LobbyGameGroup> LobbyGameGroups { get; set; } 

        public virtual Template Template { get; set; }

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
