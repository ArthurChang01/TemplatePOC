using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TemplatePOC.Web.Controllers.MVC
{
    public class GameLobbyController : Controller
    {
        public ActionResult GameLobby1()
        {
            return View();
        }

        public ActionResult GameLobby2(Guid id)
        {
            return View();
        }
    }
}
