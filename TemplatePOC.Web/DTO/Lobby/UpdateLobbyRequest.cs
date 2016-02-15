using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemplatePOC.Web.DTO.Lobby
{
    public class UpdateLobbyRequest
    {
        public Models.Template.POCO.Lobby Lobby { get; set; }

        public IEnumerable<Guid> Updated { get; set; }
        
        public IEnumerable<Guid> Removed { get; set; }  
    }
}