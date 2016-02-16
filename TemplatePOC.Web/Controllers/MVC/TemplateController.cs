using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TemplatePOC.Web.Controllers.MVC
{
    public class TemplateController : Controller
    {
        [Route("/Template/AG/:id:GUID")]
        public ActionResult Template1()
        {
            return View();
        }

        [Route("/Template/SubetCredit/:id:GUID")]
        public ActionResult Template2(Guid id)
        {
            return View();
        }
    }
}
