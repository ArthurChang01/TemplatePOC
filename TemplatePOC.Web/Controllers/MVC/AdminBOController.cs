using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TemplatePOC.Web.Controllers.MVC
{
    public class AdminBOController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult LobbyDesign()
        {
            return View();
        }
    }
}