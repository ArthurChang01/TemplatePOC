using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using TemplatePOC.Web.Models.LogIn.POCO;
using TemplatePOC.Web.Models.Template;
using TemplatePOC.Web.Models.Template.POCO;
using TemplatePOC.Web.Models.Template.ValueObject;

namespace TemplatePOC.Web.Models.Template
{
    public class TemplateContextInitializer
        : DropCreateDatabaseIfModelChanges<TemplateContext>
    {
        protected override void Seed(TemplateContext context)
        {
            IEnumerable<POCO.Template> ieTemplate = new List<POCO.Template>()
            {
                new POCO.Template
            {
                Name = "Game Provider Integration Mobile",
                Type = enLobbyType.Mobile,
                Description = "Game Provider Integration Mobile",
                Status = enLobbyStatus.Activate,
                PreviewUrl = "http://www.google.com.tw",
                Lobbies = new List<Lobby>()
                {
                    new Lobby()
                    {
                        Name="Game Provider Integration Mobile",
                        Type = enLobbyType.Mobile,
                        Description = "Game Provider Integration Mobile"
                    }
                }
            },
                new POCO.Template
            {
                Name = "Game Provider Integration",
                Type = enLobbyType.Desktop,
                Description = "Game Provider Integration",
                Status = enLobbyStatus.Activate,
                PreviewUrl = "http://www.google.com.tw",
                Lobbies = new List<Lobby>()
                {
                    new Lobby()
                    {
                        Name="Game Provider Integration",
                        Type = enLobbyType.Mobile,
                        Description = "Game Provider Integration"
                    }
                }
            },
                new POCO.Template
            {
                Name = "TLC",
                Type = enLobbyType.Desktop,
                Description = "TLC",
                Status = enLobbyStatus.Activate,
                PreviewUrl = "http://www.google.com.tw",
                Lobbies = new List<Lobby>()
                {
                    new Lobby()
                    {
                        Name="TLC",
                        Type = enLobbyType.Mobile,
                        Description = "TLC"
                    }
                }
            },
                new POCO.Template
            {
                Name = "RB88",
                Type = enLobbyType.Mobile,
                Description = "RB88",
                Status = enLobbyStatus.Activate,
                PreviewUrl = "http://www.google.com.tw",
                Lobbies = new List<Lobby>()
                {
                    new Lobby()
                    {
                        Name="RB88",
                        Type = enLobbyType.Mobile,
                        Description = "RB88"
                    }
                }
            },
                new POCO.Template
            {
                Name = "Fun88",
                Type = enLobbyType.Mobile,
                Description = "Fun88",
                Status = enLobbyStatus.Activate,
                PreviewUrl = "http://www.google.com.tw"
            }
            };

            context.Templates.AddRange(ieTemplate);




            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {

                throw ex;
            }

        }
    }
}