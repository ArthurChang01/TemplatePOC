using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemplatePOC.Web.Models.Template.POCO;

namespace TemplatePOC.Web.DTO.Template
{
    public class UpdateTemplateRequest
    {
        public Models.Template.POCO.Template Template { get; set; }

        public Guid[] Removed { get; set; }

        public Guid[] Updated { get; set; }
    }
}