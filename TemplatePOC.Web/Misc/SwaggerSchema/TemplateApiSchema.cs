using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemplatePOC.Web.DTO.Template;

namespace TemplatePOC.Web.Misc.SwaggerSchema
{
    public class TemplateApiSchema : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        {
            if (type == typeof(GetTemplatesResponse))
                schema.example = new GetTemplatesResponse() { };

            if (type == typeof(GetTemplateByResponse))
                schema.example = new GetTemplateByResponse() { };

            if (type == typeof(UpdateTemplateRequest))
                schema.example = new UpdateTemplateRequest() { };

            if (type == typeof(ChangeStatusRequest))
                schema.example = new ChangeStatusRequest() { };
        }
    }
}