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
    public class VeiculosController : Controller
    {
        private bd_gestmoveEntities db = new bd_gestmoveEntities();

        // GET: Veiculos
        [Authorize]
        public ActionResult Index()
        {
            //var motoristas = db.tb_pessoa.Select(x => new { x.ID_pessoa, x.nome_abreviado });
            return View(db.tb_veiculo.ToList());
        }

        // GET: Veiculos/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_veiculo tb_veiculo = db.tb_veiculo.Find(id);
            if (tb_veiculo == null)
            {
                return HttpNotFound();
            }
            return View(tb_veiculo);
        }

        // GET: Veiculos/Create
        [Authorize]
        public ActionResult Create()
        {
            var clientes = db.tb_pessoa.Select(x => new { x.ID_pessoa, x.tipo, x.nome_abreviado }).Where(s => s.tipo == 2);
            ViewBag.cod_fornecedor = new SelectList(clientes, "ID_pessoa", "nome_abreviado");
            
            return View();
        }

        // POST: Veiculos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_veiculo,proprio_alugado,cod_fornecedor,placa,uf,chassi,tipo_chassi,marca,modelo,cor,km,combustivel,observacao")] tb_veiculo tb_veiculo)
        {
            if (ModelState.IsValid)
            {
                db.tb_veiculo.Add(tb_veiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var clientes = db.tb_pessoa.Select(x => new { x.ID_pessoa, x.tipo, x.nome_abreviado }).Where(s => s.tipo == 2);
            ViewBag.cod_fornecedor = new SelectList(clientes, "ID_pessoa", "nome_abreviado");

            return View(tb_veiculo);
        }

        // GET: Veiculos/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_veiculo tb_veiculo = db.tb_veiculo.Find(id);
            if (tb_veiculo == null)
            {
                return HttpNotFound();
            }
            return View(tb_veiculo);
        }

        // POST: Veiculos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_veiculo,proprio_alugado,cod_fornecedor,placa,uf,chassi,tipo_chassi,marca,modelo,cor,km,combustivel,observacao")] tb_veiculo tb_veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_veiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_veiculo);
        }

        // GET: Veiculos/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_veiculo tb_veiculo = db.tb_veiculo.Find(id);
            if (tb_veiculo == null)
            {
                return HttpNotFound();
            }
            return View(tb_veiculo);
        }

        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_veiculo tb_veiculo = db.tb_veiculo.Find(id);
            db.tb_veiculo.Remove(tb_veiculo);
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
