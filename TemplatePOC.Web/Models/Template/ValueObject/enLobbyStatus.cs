using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemplatePOC.Web.Models.Template.ValueObject
{
    public enum enLobbyStatus:byte
    {
        Activate = 0,
        Inactive,
        Maintanance,
        Archive
    }
}