using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Gestmove.Models;

namespace Gestmove.Controllers
{
    public class HomeController : Controller
    {

        private bd_gestmoveEntities db = new bd_gestmoveEntities();

        [Authorize]
        public ActionResult Index()
        {
            var motoristas = db.tb_pessoa.Select(x => new { x.ID_pessoa, x.tipo }).Where(s => s.tipo == 3).Count();
            var clientes = db.tb_pessoa.Select(x => new { x.ID_pessoa, x.tipo }).Where(s => s.tipo == 2).Count();
            var veiculos = db.tb_veiculo.Select(x => new { x.cod_veiculo, x.proprio_alugado }).Where(s => s.proprio_alugado == "Sim").Count();
            var ocorrencias = db.tb_ocorrencia.Select(x => new { x.cod_ocorrencia }).Count();
            var tb_viagem = db.tb_viagem.Include(t => t.tb_pessoa).Include(t => t.tb_pessoa1).Include(t => t.tb_veiculo);

            ViewBag.cod_motoristas = motoristas;
            ViewBag.cod_clientes = clientes;
            ViewBag.cod_veiculos = veiculos;
            ViewBag.cod_ocorrencias = ocorrencias;
            ViewBag.cod_viagens = tb_viagem;

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