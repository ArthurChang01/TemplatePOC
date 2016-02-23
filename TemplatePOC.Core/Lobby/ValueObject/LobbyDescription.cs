using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplatePOC.Core.Lobby.Enums;

namespace TemplatePOC.Core.Lobby.ValueObject
{
    public class LobbyDescription
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public enLobbyType Type { get; set; }

        public enLobbyStatus Status { get; set; }

        public string CSS { get; set; }
    }
}
