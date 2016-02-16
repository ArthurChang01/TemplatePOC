using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Http;
using AutoMapper;
using TemplatePOC.Web.Models.Template;
using TemplatePOC.Web.Models.Template.POCO;
using TemplatePOC.Web.DTO.Template;
using TemplatePOC.Web.Models.Template.ValueObject;

namespace TemplatePOC.Web.Controllers.API
{
    [RoutePrefix("api/Template")]
    public class TemplateController : ApiController
    {
        public TemplateContext ctx = new TemplateContext();

        [HttpGet]
        public async Task<IHttpActionResult> GetTemplates(int index, int limit)
        {
            IEnumerable<GetTemplatesResponse> ieGroup = null;
            int startPage = (index - 1) * limit;

            try
            {
                var result = await ctx.Templates
                                             .Where(o=>o.Status!= enLobbyStatus.Archive)
                                             .OrderByDescending(o => o.CreatedDate)
                                             .Skip(startPage)
                                             .Take(limit)
                                             .Select(o => new 
                                             {
                                                 Id = o.Id,
                                                 Name=o.Name,
                                                 Type=o.Type,
                                                 Description=o.Description,
                                                 Status= o.Status,
                                                 CreatedDate=o.CreatedDate,
                                                 UpdatedDate=o.UpdatedDate,
                                                 Credential=o.Credential
                                             })
                                             .ToListAsync();
                ieGroup = (new MapperConfiguration(cfg => cfg.CreateMissingTypeMaps = true)
                                            .CreateMapper()
                                            .Map<IEnumerable<GetTemplatesResponse>>(result));
            }
            catch (Exception ex)
            { return InternalServerError(ex); }

            return Ok(ieGroup);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetBy(Guid id)
        {
            GetTemplateByResponse template = null;

            try
            {
                template = await ctx.Templates.Include("GameGroups")
                                              .Where(o => o.Id == id)
                                              .Select(o => new GetTemplateByResponse
                                              {
                                                  Id = o.Id,
                                                  Name = o.Name,
                                                  Type = o.Type,
                                                  Description = o.Description,
                                                  Status = o.Status,
                                                  PreviewUrl = o.PreviewUrl,
                                                  CreatedDate = o.CreatedDate,
                                                  UpdatedDate = o.UpdatedDate,
                                                  Credential = o.Credential,
                                                  GameGroups=o.GameGroups.Select(g=>new GameGroup() {
                                                      Id = g.Id,
                                                      Name = g.Name,
                                                      ShortName = g.ShortName,
                                                      Code=g.Code,
                                                      Description=g.Description,
                                                      Path=g.Path,
                                                      TemplateId=g.TemplateId,
                                                      CreateDate=g.CreatedDate,
                                                      UpdateDate=g.UpdatedDate
                                                  })
                                              })
                                              .FirstOrDefaultAsync();
            }
            catch (Exception ex) { return InternalServerError(ex); }

            return Ok(template);
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddTemplate(Template template)
        {
            try
            {
                ctx.Templates.Add(template);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex) { return InternalServerError(ex); }

            return Ok();
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateTemplate(UpdateTemplateRequest dto)
        {
            dto.Template.GameGroups.ForEach(o => o.TemplateId = dto.Template.Id);

            try
            {
                ctx.Entry<Template>(dto.Template).State = EntityState.Modified;
                dto.Template.GameGroups.ForEach(o => {
                    if (dto.Updated.Contains(o.Id))
                        ctx.Entry<TemplateGameGroup>(o).State = EntityState.Modified;
                    else if (o.Id == Guid.Empty)
                        ctx.Entry<TemplateGameGroup>(o).State = EntityState.Added;
                });

                TemplateGameGroup group = null;
                dto.Removed.ToList().ForEach(o => {
                    group = new TemplateGameGroup() { Id = o };
                    ctx.Entry<TemplateGameGroup>(group).State = EntityState.Deleted;
                });

                await ctx.SaveChangesAsync();
            }
            catch (Exception ex) { return InternalServerError(ex); }

            return Ok();
        }

        [HttpPatch]
        public async Task<IHttpActionResult> ChangeStatus(ChangeStatusRequest dto)
        {
            Template template = new Template() { Id = dto.Id, Status =(enLobbyStatus)Enum.Parse(typeof(enLobbyStatus), dto.Status) };

            try
            {
                string[] arProp = new string[] {"Id","Status", "GameGroups","Template","Lobbies"};
                var entry = ctx.Entry<Template>(template);
                entry.State = EntityState.Modified;
                typeof(Template).GetProperties().Select(o=>o.Name).Where(o=>!arProp.Contains(o)).ToList()
                    .ForEach(o=>entry.Property(o).IsModified=false);

                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok();
        }
    }
}
