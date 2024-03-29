﻿using System;
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
    public class LocacoesController : Controller
    {
        private bd_gestmoveEntities db = new bd_gestmoveEntities();

        // GET: Locacoes
        [Authorize]
        public ActionResult Index()
        {
            var tb_locacao = db.tb_locacao.Include(t => t.tb_pessoa).Include(t => t.tb_veiculo);
            return View(tb_locacao.ToList());
        }

        // GET: Locacoes/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_locacao tb_locacao = db.tb_locacao.Find(id);
            if (tb_locacao == null)
            {
                return HttpNotFound();
            }
            return View(tb_locacao);
        }

        // GET: Locacoes/Create
        [Authorize]
        public ActionResult Create()
        {
            var clientes = db.tb_pessoa.Select(x => new { x.ID_pessoa, x.tipo, x.nome_abreviado }).Where(s => s.tipo == 1);
            var veiculos = db.tb_veiculo.Select(x => new { x.cod_veiculo, x.modelo, x.proprio_alugado }).Where(s => s.proprio_alugado == "Sim");

            ViewBag.cod_pessoa = new SelectList(clientes, "ID_pessoa", "nome_abreviado");
            ViewBag.cod_veiculo = new SelectList(veiculos, "cod_veiculo", "modelo");

            return View();
        }

        // POST: Locacoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_locacao,cod_pessoa,cod_veiculo,data_locacao,data_entrega,qtd_dias,km_original,km_nova,valor_locacao,NF")] tb_locacao tb_locacao)
        {
            if (ModelState.IsValid)
            {
                db.tb_locacao.Add(tb_locacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var clientes = db.tb_pessoa.Select(x => new { x.ID_pessoa, x.tipo, x.nome_abreviado }).Where(s => s.tipo == 1);
            var veiculos = db.tb_veiculo.Select(x => new { x.cod_veiculo, x.modelo, x.proprio_alugado }).Where(s => s.proprio_alugado == "Sim");

            ViewBag.cod_pessoa = new SelectList(clientes, "ID_pessoa", "nome_abreviado");
            ViewBag.cod_veiculo = new SelectList(veiculos, "cod_veiculo", "modelo");

            return View(tb_locacao);
        }

        // GET: Locacoes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_locacao tb_locacao = db.tb_locacao.Find(id);
            if (tb_locacao == null)
            {
                return HttpNotFound();
            }

            var clientes = db.tb_pessoa.Select(x => new { x.ID_pessoa, x.tipo, x.nome_abreviado }).Where(s => s.tipo == 1);
            var veiculos = db.tb_veiculo.Select(x => new { x.cod_veiculo, x.modelo, x.proprio_alugado }).Where(s => s.proprio_alugado == "Sim");


            ViewBag.cod_pessoa = new SelectList(clientes, "ID_pessoa", "nome_abreviado");
            ViewBag.cod_veiculo = new SelectList(veiculos, "cod_veiculo", "modelo");
            
            return View(tb_locacao);
        }

        // POST: Locacoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_locacao,cod_pessoa,cod_veiculo,data_locacao,data_entrega,qtd_dias,km_original,km_nova,valor_locacao,NF")] tb_locacao tb_locacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_locacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_pessoa = new SelectList(db.tb_pessoa, "ID_pessoa", "nome_abreviado", tb_locacao.cod_pessoa);
            ViewBag.cod_veiculo = new SelectList(db.tb_veiculo, "cod_veiculo", "proprio_alugado", tb_locacao.cod_veiculo);
            return View(tb_locacao);
        }

        // GET: Locacoes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_locacao tb_locacao = db.tb_locacao.Find(id);
            if (tb_locacao == null)
            {
                return HttpNotFound();
            }
            return View(tb_locacao);
        }

        // POST: Locacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_locacao tb_locacao = db.tb_locacao.Find(id);
            db.tb_locacao.Remove(tb_locacao);
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
