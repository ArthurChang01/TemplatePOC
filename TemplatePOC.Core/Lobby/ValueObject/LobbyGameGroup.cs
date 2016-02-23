using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePOC.Core.Lobby.ValueObject
{
    public class LobbyGameGroup
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string Path { get; set; }

        public Guid LobbyId { get; set; }

        public virtual Entity.Lobby Lobby { get; set; }
    }
}
