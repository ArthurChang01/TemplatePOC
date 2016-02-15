using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TemplatePOC.Web.Models.Template.POCO;

namespace TemplatePOC.Web.Models.Template
{
    public class TemplateContext:DbContext
    {
        public DbSet<POCO.Template> Templates { get; set; }

        public DbSet<Lobby> Lobbies { get; set; }

        public DbSet<TemplateGameGroup> GameGroups { get; set; }

        public TemplateContext()
            : base("name=default")
        {
            Database.SetInitializer<TemplateContext>(new TemplateContextInitializer());
        }
    }
}