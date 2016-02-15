using System;

namespace TemplatePOC.Web.DTO.Lobby
{
    public class ChangeStatusRequest
    {
        public Guid Id { get; set; }

        public string Status { get; set; }
    }
}