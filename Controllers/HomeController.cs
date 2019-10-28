using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Gestmove.Models;

namespace Gestmove.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Auth()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Auth(tb_login model, string returnUrl)
        {

            bd_gestmoveEntities db = new bd_gestmoveEntities();

            var dataItem = db.tb_login.Where(x => x.usuario == model.usuario && x.senha == model.senha).FirstOrDefault();

            if (dataItem != null)
            {
                FormsAuthentication.SetAuthCookie(dataItem.usuario, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid user/pass");
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize]
        [AllowAnonymous]

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");

        }
    }
}