using System;

namespace TemplatePOC.Web.DTO.Template
{
    public class ChangeStatusRequest
    {
        public Guid Id { get; set; }

        public string Status { get; set; }
    }
}