using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemplatePOC.Web.Models.Template.POCO;
using TemplatePOC.Web.Models.Template.ValueObject;

namespace TemplatePOC.Web.DTO.Template
{
    public class GameGroup {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set;  }

        public string Code { get; set; }

        public string Description { get; set; }

        public string Path { get; set; }

        public Guid TemplateId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }

    public class GetTemplateByResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public enLobbyType Type { get; set; }

        public string Description { get; set; }

        public enLobbyStatus Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string PreviewUrl { get; set; }

        public string Credential { get; set; }

        public IEnumerable<GameGroup> GameGroups { get; set; }
    }
}