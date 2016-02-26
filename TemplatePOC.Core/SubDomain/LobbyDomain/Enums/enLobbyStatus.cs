using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePOC.Core.SubDomain.LobbyDomain.Enums
{
    public enum enLobbyStatus:byte
    {
        Activate = 0,
        Inactive,
        Maintanance,
        Archive
    }
}
