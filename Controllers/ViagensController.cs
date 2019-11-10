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
    public class ViagensController : Controller
    {
        private bd_gestmoveEntities db = new bd_gestmoveEntities();

        // GET: Viagens
        [Authorize]
        public ActionResult Index()
        {
            var tb_viagem = db.tb_viagem.Include(t => t.tb_pessoa).Include(t => t.tb_pessoa1).Include(t => t.tb_veiculo);
            return View(tb_viagem.ToList());
        }

        // GET: Viagens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_viagem tb_viagem = db.tb_viagem.Find(id);
            if (tb_viagem == null)
            {
                return HttpNotFound();
            }
            return View(tb_viagem);
        }

        // GET: Viagens/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.cod_cliente = new SelectList(db.tb_pessoa, "ID_pessoa", "nome_abreviado");
            ViewBag.cod_motorista = new SelectList(db.tb_pessoa, "ID_pessoa", "nome_abreviado");
            ViewBag.cod_veiculo = new SelectList(db.tb_veiculo, "cod_veiculo", "proprio_alugado");
            return View();
        }

        // POST: Viagens/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_viagem,cod_motorista,cod_cliente,cod_veiculo,data_saida,prev_chegada,data_chegada,valor,NF")] tb_viagem tb_viagem)
        {
            if (ModelState.IsValid)
            {
                db.tb_viagem.Add(tb_viagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_cliente = new SelectList(db.tb_pessoa, "ID_pessoa", "nome_abreviado", tb_viagem.cod_cliente);
            ViewBag.cod_motorista = new SelectList(db.tb_pessoa, "ID_pessoa", "nome_abreviado", tb_viagem.cod_motorista);
            ViewBag.cod_veiculo = new SelectList(db.tb_veiculo, "cod_veiculo", "proprio_alugado", tb_viagem.cod_veiculo);
            return View(tb_viagem);
        }

        // GET: Viagens/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_viagem tb_viagem = db.tb_viagem.Find(id);
            if (tb_viagem == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_cliente = new SelectList(db.tb_pessoa, "ID_pessoa", "nome_abreviado", tb_viagem.cod_cliente);
            ViewBag.cod_motorista = new SelectList(db.tb_pessoa, "ID_pessoa", "nome_abreviado", tb_viagem.cod_motorista);
            ViewBag.cod_veiculo = new SelectList(db.tb_veiculo, "cod_veiculo", "proprio_alugado", tb_viagem.cod_veiculo);
            return View(tb_viagem);
        }

        // POST: Viagens/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_viagem,cod_motorista,cod_cliente,cod_veiculo,data_saida,prev_chegada,data_chegada,valor,NF")] tb_viagem tb_viagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_viagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_cliente = new SelectList(db.tb_pessoa, "ID_pessoa", "nome_abreviado", tb_viagem.cod_cliente);
            ViewBag.cod_motorista = new SelectList(db.tb_pessoa, "ID_pessoa", "nome_abreviado", tb_viagem.cod_motorista);
            ViewBag.cod_veiculo = new SelectList(db.tb_veiculo, "cod_veiculo", "proprio_alugado", tb_viagem.cod_veiculo);
            return View(tb_viagem);
        }

        // GET: Viagens/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_viagem tb_viagem = db.tb_viagem.Find(id);
            if (tb_viagem == null)
            {
                return HttpNotFound();
            }
            return View(tb_viagem);
        }

        // POST: Viagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_viagem tb_viagem = db.tb_viagem.Find(id);
            db.tb_viagem.Remove(tb_viagem);
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
