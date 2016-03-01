using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemplatePOC.Web.DTO.Lobby;

namespace TemplatePOC.Web.Misc.SwaggerSchema
{
    public class LobbyApiSchema : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        {
            if (type == typeof(GetLobbyResponse))
                schema.example = new GetLobbyResponse() { };

            if (type == typeof(GetByResponse))
                schema.example = new GetByResponse() { };

            if (type == typeof(UpdateLobbyRequest))
                schema.example = new UpdateLobbyRequest() { };

            if (type == typeof(ChangeStatusRequest))
                schema.example = new ChangeStatusRequest() { };
        }
    }
}