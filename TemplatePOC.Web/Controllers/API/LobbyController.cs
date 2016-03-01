using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TemplatePOC.Web.DTO.Lobby;
using TemplatePOC.Web.Models.Template;
using TemplatePOC.Web.Models.Template.POCO;
using TemplatePOC.Web.Models.Template.ValueObject;
using GameGroup = TemplatePOC.Web.DTO.Lobby.GameGroup;
using Swashbuckle.Swagger.Annotations;
using TemplatePOC.Web.Misc.Log;

namespace TemplatePOC.Web.Controllers.API
{
    [RoutePrefix("api/Lobby")]
    public class LobbyController : ApiController
    {
        public TemplateContext ctx = new TemplateContext();

        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, @"取得大廳列表", typeof(IEnumerable<GetLobbyResponse>))]
        //[SwaggerResponse(HttpStatusCode.InternalServerError, @"錯誤內容", typeof(ErrorOutDto))]
        public async Task<IHttpActionResult> GetLobbies(int index, int limit)
        {
            IEnumerable<GetLobbyResponse> ieGroup = null;
            int startPage = (index - 1) * limit;

            try
            {
                var result = await ctx.Lobbies
                    .Where(o => o.Status != enLobbyStatus.Archive)
                    .OrderByDescending(o => o.CreatedDate)
                    .Skip(startPage)
                    .Take(limit)
                    .Select(o => new
                    {
                        Id = o.Id,
                        Name = o.Name,
                        TemplateName = o.Template.Name,
                        Type = o.Type,
                        Description = o.Description,
                        Status = o.Status,
                        CreateDate = o.CreatedDate,
                        UpdateDate = o.UpdatedDate,
                        Credential = o.Credential
                    })
                    .ToListAsync();

                ieGroup = (new MapperConfiguration(cfg =>cfg.CreateMissingTypeMaps = true)
                                            .CreateMapper()
                                            .Map<IEnumerable<GetLobbyResponse>>(result));

            }
            catch (Exception ex)
            {
                ex = ex.InnerException ?? ex;
                Logger.Exception_Error(ex);
                return InternalServerError(ex);
            }

            return Ok(ieGroup);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetBy(Guid id)
        {
            GetByResponse group = null;

            try
            {
                group = await (from lobby in ctx.Lobbies
                               where lobby.Id == id
                               select new GetByResponse
                               {
                                   Id = lobby.Id,
                                   Name = lobby.Name,
                                   Type = lobby.Type,
                                   Description = lobby.Description,
                                   Status = lobby.Status,
                                   TemplateId = lobby.TemplateId,
                                   CSS = lobby.CSS,
                                   CreatedDate = lobby.CreatedDate,
                                   UpdatedDate = lobby.UpdatedDate,
                                   GameGroups = lobby.GameGroups.Select(g => new GameGroup()
                                   {
                                       Id = g.Id,
                                       Name = g.Name,
                                       ShortName = g.ShortName,
                                       Code = g.Code,
                                       Description = g.Description,
                                       Path = g.Path,
                                       TemplateId = lobby.TemplateId,
                                       CreateDate = g.CreatedDate,
                                       UpdateDate = g.UpdatedDate
                                   }),
                                   Templates = ctx.Templates.Select(o => new TemplateItem() { Id = o.Id, Name = o.Name, PreviewUrl = o.PreviewUrl})
                               })
                    .FirstOrDefaultAsync();

            }
            catch (Exception ex) {
                ex = ex.InnerException ?? ex;
                Logger.Exception_Error(ex);
                return InternalServerError(ex);
            }

            return Ok(group);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetTemplateItem()
        {
            IEnumerable<TemplateItem> ieTemplateItem = null;

            try
            {
                ieTemplateItem = await ctx.Templates
                        .Select(o =>
                            new TemplateItem()
                            {
                                Id = o.Id,
                                Name = o.Name,
                                PreviewUrl = o.PreviewUrl
                            }).ToListAsync();
            }
            catch (Exception ex)
            {
                ex = ex.InnerException ?? ex;
                Logger.Exception_Error(ex);
                return InternalServerError(ex);
            }

            return Ok(ieTemplateItem);
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddLobby(Lobby lobby)
        {
            try
            {
                ctx.Lobbies.Add(lobby);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex) {
                ex = ex.InnerException ?? ex;
                Logger.Exception_Error(ex);
                return InternalServerError(ex);
            }

            return Ok();
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateLobby(UpdateLobbyRequest dto)
        {
            dto.Lobby.GameGroups.ForEach(o => o.LobbyId = dto.Lobby.Id);

            try
            {
                ctx.Entry<Lobby>(dto.Lobby).State = EntityState.Modified;
                dto.Lobby.GameGroups.ForEach(o =>
                {
                    if (dto.Updated.Contains(o.Id))
                        ctx.Entry<LobbyGameGroup>(o).State = EntityState.Modified;
                    else if (o.Id == Guid.Empty)
                        ctx.Entry<LobbyGameGroup>(o).State = EntityState.Added;
                });

                LobbyGameGroup group = null;
                dto.Removed.ToList().ForEach(o =>
                {
                    group = new LobbyGameGroup() { Id = o };
                    ctx.Entry<LobbyGameGroup>(group).State = EntityState.Deleted;
                });

                await ctx.SaveChangesAsync();
            }
            catch (Exception ex) {
                ex = ex.InnerException ?? ex;
                Logger.Exception_Error(ex);
                return InternalServerError(ex);
            }

            return Ok();
        }

        [HttpPatch]
        public async Task<IHttpActionResult> ChangeStatus(ChangeStatusRequest dto)
        {
            Lobby template = new Lobby() { Id = dto.Id, Status = (enLobbyStatus)Enum.Parse(typeof(enLobbyStatus), dto.Status) };

            try
            {
                string[] arProp = new string[] { "Id", "Status", "GameGroups", "Template" };
                var entry = ctx.Entry<Lobby>(template);
                entry.State = EntityState.Modified;
                typeof(Lobby).GetProperties().Select(o => o.Name).Where(o => !arProp.Contains(o)).ToList()
                    .ForEach(o => entry.Property(o).IsModified = false);

                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex = ex.InnerException ?? ex;
                Logger.Exception_Error(ex);
                return InternalServerError(ex);
            }
            return Ok();
        }

    }
}
