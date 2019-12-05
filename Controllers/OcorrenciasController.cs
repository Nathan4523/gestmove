using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gestmove.Models;

namespace Gestmove.Controllers
{
    public class OcorrenciasController : Controller
    {
        private bd_gestmoveEntities db = new bd_gestmoveEntities();

        // GET: Oorrencias
        [Authorize]
        public ActionResult Index()
        {
            var tb_ocorrencia = db.tb_ocorrencia.Include(t => t.tb_pessoa).Include(t => t.tb_veiculo).Include(t => t.tb_viagem);
            return View(tb_ocorrencia.ToList());
        }

        // GET: Oorrencias/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ocorrencia tb_ocorrencia = db.tb_ocorrencia.Find(id);
            if (tb_ocorrencia == null)
            {
                return HttpNotFound();
            }
            return View(tb_ocorrencia);
        }

        // GET: Oorrencias/Create
        [Authorize]
        public ActionResult Create()
        {
            var motoristas = db.tb_pessoa.Select(x => new { x.ID_pessoa, x.tipo, x.nome_abreviado }).Where(s => s.tipo == 3);
            var veiculos = db.tb_veiculo.Select(x => new { x.cod_veiculo, x.modelo, x.proprio_alugado }).Where(s => s.proprio_alugado == "Nao");
            var viagens = db.tb_viagem.Select(x => new { x.cod_viagem, x.NF });

            ViewBag.cod_motorista = new SelectList(motoristas, "ID_pessoa", "nome_abreviado");
            ViewBag.cod_veiculo = new SelectList(veiculos, "cod_veiculo", "modelo");
            ViewBag.cod_viagem = new SelectList(viagens, "cod_viagem", "NF");

            return View();
        }

        // POST: Oorrencias/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_viagem,cod_motorista,cod_veiculo,motivo,pontos,valor,obs_motorista")] tb_ocorrencia tb_ocorrencia)
        {
            if (ModelState.IsValid)
            {
                db.tb_ocorrencia.Add(tb_ocorrencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_motorista = new SelectList(db.tb_pessoa, "ID_pessoa", "nome_abreviado", tb_ocorrencia.cod_motorista);
            ViewBag.cod_veiculo = new SelectList(db.tb_veiculo, "cod_veiculo", "proprio_alugado", tb_ocorrencia.cod_veiculo);
            ViewBag.cod_viagem = new SelectList(db.tb_viagem, "cod_viagem", "cod_viagem", tb_ocorrencia.cod_viagem);
            return View(tb_ocorrencia);
        }

        // GET: Oorrencias/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ocorrencia tb_ocorrencia = db.tb_ocorrencia.Find(id);
            if (tb_ocorrencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_motorista = new SelectList(db.tb_pessoa, "ID_pessoa", "nome_abreviado", tb_ocorrencia.cod_motorista);
            ViewBag.cod_veiculo = new SelectList(db.tb_veiculo, "cod_veiculo", "proprio_alugado", tb_ocorrencia.cod_veiculo);
            ViewBag.cod_viagem = new SelectList(db.tb_viagem, "cod_viagem", "cod_viagem", tb_ocorrencia.cod_viagem);
            return View(tb_ocorrencia);
        }

        // POST: Oorrencias/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_ocorrencia,cod_viagem,cod_motorista,cod_veiculo,motivo,pontos,valor,obs_motorista")] tb_ocorrencia tb_ocorrencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_ocorrencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_motorista = new SelectList(db.tb_pessoa, "ID_pessoa", "nome_abreviado", tb_ocorrencia.cod_motorista);
            ViewBag.cod_veiculo = new SelectList(db.tb_veiculo, "cod_veiculo", "proprio_alugado", tb_ocorrencia.cod_veiculo);
            ViewBag.cod_viagem = new SelectList(db.tb_viagem, "cod_viagem", "cod_viagem", tb_ocorrencia.cod_viagem);
            return View(tb_ocorrencia);
        }

        // GET: Oorrencias/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ocorrencia tb_ocorrencia = db.tb_ocorrencia.Find(id);
            if (tb_ocorrencia == null)
            {
                return HttpNotFound();
            }
            return View(tb_ocorrencia);
        }

        // POST: Oorrencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_ocorrencia tb_ocorrencia = db.tb_ocorrencia.Find(id);
            db.tb_ocorrencia.Remove(tb_ocorrencia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
