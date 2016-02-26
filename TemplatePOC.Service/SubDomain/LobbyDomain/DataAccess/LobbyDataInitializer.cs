using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplatePOC.Core.SubDomain.LobbyDomain.Entity;
using TemplatePOC.Core.SubDomain.LobbyDomain.Enums;

namespace TemplatePOC.Service.SubDomain.LobbyDomain.DataAccess
{
    public class LobbyDataInitializer : DropCreateDatabaseIfModelChanges<LobbyContext>
    {
        protected override void Seed(LobbyContext context)
        {
            IEnumerable<Template> ieTemplate = new List<Template>()
            {
                new Template
            {
                   Description=new Core.SubDomain.LobbyDomain.ValueObject.TemplateDescription() {
                       Name = "Game Provider Integration Mobile",
                Type = enLobbyType.Mobile,
                Description = "Game Provider Integration Mobile",
                Status = enLobbyStatus.Activate,
                PreviewUrl = "/Template/Template1"
                   },



                Lobbies = new List<Lobby>()
                {
                    new Lobby()
                    {
                        Description=new Core.SubDomain.LobbyDomain.ValueObject.LobbyDescription() {
                            Name="Game Provider Integration Mobile",
                        Type = enLobbyType.Mobile
                        }
                    }
                }
            },
                new Template
            {
                    Description=new Core.SubDomain.LobbyDomain.ValueObject.TemplateDescription() {
                        Name = "Game Provider Integration",
                Type = enLobbyType.Desktop,
                Description = "Game Provider Integration",
                Status = enLobbyStatus.Activate,
                PreviewUrl = "/Template/Template1",
                    },

                Lobbies = new List<Lobby>()
                {
                    new Lobby()
                    {
                        Description=new Core.SubDomain.LobbyDomain.ValueObject.LobbyDescription() {
                            Name="Game Provider Integration",
                        Type = enLobbyType.Mobile
                        }
                    }
                }
            },
                new Template
            {
                    Description=new Core.SubDomain.LobbyDomain.ValueObject.TemplateDescription() {
                        Name = "TLC",
                Type = enLobbyType.Desktop,
                Description = "TLC",
                Status = enLobbyStatus.Activate,
                PreviewUrl = "/Template/Template1"
                    },

                Lobbies = new List<Lobby>()
                {
                    new Lobby()
                    {
                        Description=new Core.SubDomain.LobbyDomain.ValueObject.LobbyDescription() {
                            Name="TLC",
                        Type = enLobbyType.Mobile
                        }
                    }
                }
            },
                new Template
            {
                    Description=new Core.SubDomain.LobbyDomain.ValueObject.TemplateDescription() {
                        Name = "RB88",
                Type = enLobbyType.Mobile,
                Description = "RB88",
                Status = enLobbyStatus.Activate,
                PreviewUrl = "/Template/Template1"
                    },
                Lobbies = new List<Lobby>()
                {
                    new Lobby()
                    {
                        Description=new Core.SubDomain.LobbyDomain.ValueObject.LobbyDescription() {
                            Name="RB88",
                        Type = enLobbyType.Mobile
                        }
                    }
                }
            },
                new Template
            {
                    Description=new Core.SubDomain.LobbyDomain.ValueObject.TemplateDescription() {
                        Name = "Fun88",
                Type = enLobbyType.Mobile,
                Description = "Fun88",
                Status = enLobbyStatus.Activate,
                PreviewUrl = "/Template/Template1"
                    }

            }
            };

            context.Template.AddRange(ieTemplate);




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
