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
    public class ManutencoesController : Controller
    {
        private bd_gestmoveEntities db = new bd_gestmoveEntities();

        // GET: Manutencoes
        [Authorize]
        public ActionResult Index()
        {
            var tb_manutencao = db.tb_manutencao.Include(t => t.tb_pessoa).Include(t => t.tb_veiculo);
            return View(tb_manutencao.ToList());
        }

        // GET: Manutencoes/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_manutencao tb_manutencao = db.tb_manutencao.Find(id);
            if (tb_manutencao == null)
            {
                return HttpNotFound();
            }
            return View(tb_manutencao);
        }

        // GET: Manutencoes/Create
        [Authorize]
        public ActionResult Create()
        {
            var veiculos = db.tb_veiculo.Select(x => new { x.cod_veiculo, x.modelo, x.proprio_alugado });
            ViewBag.cod_veiculo = new SelectList(veiculos, "cod_veiculo", "modelo");

            return View();
        }

        // POST: Manutencoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_manutencao,cod_veiculo,cod_oficina,tipo,motivo,data,valor")] tb_manutencao tb_manutencao)
        {
            if (ModelState.IsValid)
            {
                db.tb_manutencao.Add(tb_manutencao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.cod_oficina = new SelectList(db.tb_pessoa, "ID_pessoa", "nome_abreviado", tb_manutencao.cod_oficina);
            
            var veiculos = db.tb_veiculo.Select(x => new { x.cod_veiculo, x.modelo, x.proprio_alugado });
            ViewBag.cod_veiculo = new SelectList(veiculos, "cod_veiculo", "modelo");
            return View(tb_manutencao);
        }

        // GET: Manutencoes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_manutencao tb_manutencao = db.tb_manutencao.Find(id);
            if (tb_manutencao == null)
            {
                return HttpNotFound();
            }
            //ViewBag.cod_oficina = new SelectList(db.tb_pessoa, "ID_pessoa", "nome_abreviado", tb_manutencao.cod_oficina);
            //ViewBag.cod_veiculo = new SelectList(db.tb_veiculo, "cod_veiculo", "proprio_alugado", tb_manutencao.cod_veiculo);
            ViewBag.cod_veiculo = new SelectList(db.tb_veiculo, "cod_veiculo", "cod_veiculo");
            return View(tb_manutencao);
        }

        // POST: Manutencoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_manutencao,cod_veiculo,cod_oficina,tipo,motivo,data,valor")] tb_manutencao tb_manutencao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_manutencao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_oficina = new SelectList(db.tb_pessoa, "ID_pessoa", "nome_abreviado", tb_manutencao.cod_oficina);
            ViewBag.cod_veiculo = new SelectList(db.tb_veiculo, "cod_veiculo", "proprio_alugado", tb_manutencao.cod_veiculo);
            return View(tb_manutencao);
        }

        // GET: Manutencoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_manutencao tb_manutencao = db.tb_manutencao.Find(id);
            if (tb_manutencao == null)
            {
                return HttpNotFound();
            }
            return View(tb_manutencao);
        }

        // POST: Manutencoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_manutencao tb_manutencao = db.tb_manutencao.Find(id);
            db.tb_manutencao.Remove(tb_manutencao);
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
