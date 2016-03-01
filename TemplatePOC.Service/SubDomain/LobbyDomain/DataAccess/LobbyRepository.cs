using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplatePOC.Service.Base;
using TemplatePOC.Core.SubDomain.LobbyDomain.Entity;
using TemplatePOC.Core.SubDomain.LobbyDomain.Interface;
using System.Data.Entity;

namespace TemplatePOC.Service.SubDomain.LobbyDomain.DataAccess
{
    public class LobbyRepository: Repository<Guid, Lobby>,ILobbyRepository
    {
        public LobbyRepository():base(new LobbyContext()) {}

        public LobbyRepository(DbContext ctx) : base(ctx) { }

    }
}
