using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemplatePOC.Web.Misc.MapProfile;

namespace TemplatePOC.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configuration() {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<LobbyProfile>();
            });
        }
    }
}