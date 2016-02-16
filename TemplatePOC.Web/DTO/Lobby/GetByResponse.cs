using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemplatePOC.Web.Models.Template.ValueObject;

namespace TemplatePOC.Web.DTO.Lobby
{
    public class TemplateItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string PreviewUrl { get; set; }
    }

    public class GameGroup
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string Path { get; set; }

        public Guid TemplateId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }

    public class GetByResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public enLobbyType Type { get; set; }

        public string Description { get; set; }

        public enLobbyStatus Status { get; set; }

        public Guid TemplateId { get; set; }

        public string CSS { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public IEnumerable<TemplateItem> Templates { get; set; } 

        public IEnumerable<GameGroup> GameGroups { get; set; }

    }
}