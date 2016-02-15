using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TemplatePOC.Web.Controllers.MVC
{
    public class ResellerBOController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Reseller()
        {
            return View();
        }

        public ActionResult Lobby()
        {
            return View();
        }
    }
}