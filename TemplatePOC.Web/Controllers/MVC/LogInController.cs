using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemplatePOC.Web.DTO.LogIn;
using TemplatePOC.Web.Models.LogIn;

namespace TemplatePOC.Web.Controllers.MVC
{
    public class LogInController : Controller
    {
        public LogInContext ctx = new LogInContext();

        [HttpGet,Route("/admin/login")]
        public ActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Admin(AdminUserLoginDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            if (!ctx.AdminUsers.Any(o => o.UserName.Equals(dto.UserName) &&
                 o.Password.Equals(dto.Password)))
            {
                ModelState.AddModelError("", "此帳號不存在");
                return View(dto);
            }

            return RedirectToAction("Index", "AdminBO");
        }

        [HttpGet,Route("/reseller/login")]
        public ActionResult Reseller()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reseller(ResellerUserLogInDTO dto) {
            if (!ModelState.IsValid)
                return View(dto);

            if (ctx.ResellerUsers.Any(o => o.UserName.Equals(dto.UserName) &&
                 o.Password.Equals(dto.Password)))
                ModelState.AddModelError("", "此帳號不存在");

            return RedirectToAction("Index", "ResellerBO");
        }
    }
}