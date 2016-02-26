using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplatePOC.Core.SubDomain.LobbyDomain.Entity;

namespace TemplatePOC.Service.SubDomain.LobbyDomain.DataAccess
{
    public class LobbyContext : DbContext
    {
        public DbSet<Template> Template { get; set; }

        public DbSet<Lobby> Lobby { get; set; }

        public DbSet<LobbyGameGroup> LobbyGameGroup { get; set; }

        public DbSet<TemplateGameGroup> TemplateGameGroup { get; set; }

        public LobbyContext()
            : base("name=default")
        {
            Database.SetInitializer<LobbyContext>(new LobbyDataInitializer());
        }
    }
}
