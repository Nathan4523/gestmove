using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gestmove.Models;

namespace Gestmove.Controllers
{
    public class PessoasController : Controller
    {
        private bd_gestmoveEntities db = new bd_gestmoveEntities();

        // GET: Pessoas
        [Authorize]
        public ActionResult Index()
        {
            return View(db.tb_pessoa.ToList());
        }

        // GET: Pessoas/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_pessoa tb_pessoa = db.tb_pessoa.Find(id);
            if (tb_pessoa == null)
            {
                return HttpNotFound();
            }
            return View(tb_pessoa);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_pessoa,tipo,nome_abreviado,razao_social,f_j,rg_cnpj,cpf_ie,logradouro,numero,compl,cep,bairro,municipio,uf,regiao,telefone,celular,email,tipo_carteira,cnh,pontos_carteira,data_contratacao,tipo_fornec_msa,tipo_msa1,tipo_msa2,tipo_msa3,observacao")] tb_pessoa tb_pessoa)
        {

            if (ModelState.IsValid)
            {
                db.tb_pessoa.Add(tb_pessoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_pessoa);
        }

        // GET: Pessoas/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_pessoa tb_pessoa = db.tb_pessoa.Find(id);
            if (tb_pessoa == null)
            {
                return HttpNotFound();
            }
            return View(tb_pessoa);
        }

        // POST: Pessoas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_pessoa,tipo,nome_abreviado,razao_social,f_j,rg_cnpj,cpf_ie,logradouro,numero,compl,cep,bairro,municipio,uf,regiao,telefone,celular,email,tipo_carteira,cnh,pontos_carteira,data_contratacao,tipo_fornec_msa,tipo_msa1,tipo_msa2,tipo_msa3,observacao")] tb_pessoa tb_pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_pessoa);
        }

        // GET: Pessoas/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_pessoa tb_pessoa = db.tb_pessoa.Find(id);
            if (tb_pessoa == null)
            {
                return HttpNotFound();
            }
            return View(tb_pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_pessoa tb_pessoa = db.tb_pessoa.Find(id);
            db.tb_pessoa.Remove(tb_pessoa);
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
