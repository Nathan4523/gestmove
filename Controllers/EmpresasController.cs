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
    public class EmpresasController : Controller
    {
        private bd_gestmoveEntities db = new bd_gestmoveEntities();

        // GET: Empresas
        public ActionResult Index()
        {
            return View(db.tb_empresa.ToList());
        }

        // GET: Empresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_empresa tb_empresa = db.tb_empresa.Find(id);
            if (tb_empresa == null)
            {
                return HttpNotFound();
            }
            return View(tb_empresa);
        }

        // GET: Empresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_empresa,nome_abreviado,razao_social,cnpj,ie,logradouro,numero,compl,cep,bairro,municipio,uf,regiao,telefone,celular,contato,email,observacao")] tb_empresa tb_empresa)
        {
            if (ModelState.IsValid)
            {
                db.tb_empresa.Add(tb_empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_empresa);
        }

        // GET: Empresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_empresa tb_empresa = db.tb_empresa.Find(id);
            if (tb_empresa == null)
            {
                return HttpNotFound();
            }
            return View(tb_empresa);
        }

        // POST: Empresas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_empresa,nome_abreviado,razao_social,cnpj,ie,logradouro,numero,compl,cep,bairro,municipio,uf,regiao,telefone,celular,contato,email,observacao")] tb_empresa tb_empresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_empresa);
        }

        // GET: Empresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_empresa tb_empresa = db.tb_empresa.Find(id);
            if (tb_empresa == null)
            {
                return HttpNotFound();
            }
            return View(tb_empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_empresa tb_empresa = db.tb_empresa.Find(id);
            db.tb_empresa.Remove(tb_empresa);
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
