﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemplatePOC.Web.Models.Template.POCO;

namespace TemplatePOC.Web.DTO.Template
{
    public class GetTemplatesResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string Credential { get; set; }
    }
}