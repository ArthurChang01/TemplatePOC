using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemplatePOC.Web.Misc.MapProfile
{
    public class LobbyProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "LobbyProfile";
            }
        }

        protected override void Configure()
        {
            //Mapper.CreateMap<>();
        }
    }
}