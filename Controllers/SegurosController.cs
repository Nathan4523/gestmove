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
    public class SegurosController : Controller
    {
        private bd_gestmoveEntities db = new bd_gestmoveEntities();

        // GET: Seguros
        [Authorize]
        public ActionResult Index()
        {
            var tb_seguro = db.tb_seguro.Include(t => t.tb_veiculo);
            return View(tb_seguro.ToList());
        }

        // GET: Seguros/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_seguro tb_seguro = db.tb_seguro.Find(id);
            if (tb_seguro == null)
            {
                return HttpNotFound();
            }
            return View(tb_seguro);
        }

        // GET: Seguros/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.cod_veiculo = new SelectList(db.tb_veiculo, "cod_veiculo", "proprio_alugado");
            return View();
        }

        // POST: Seguros/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_seguro,cnh,rg,crv,crvl,cod_veiculo")] tb_seguro tb_seguro)
        {
            if (ModelState.IsValid)
            {
                db.tb_seguro.Add(tb_seguro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_veiculo = new SelectList(db.tb_veiculo, "cod_veiculo", "proprio_alugado", tb_seguro.cod_veiculo);
            return View(tb_seguro);
        }

        // GET: Seguros/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_seguro tb_seguro = db.tb_seguro.Find(id);
            if (tb_seguro == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_veiculo = new SelectList(db.tb_veiculo, "cod_veiculo", "proprio_alugado", tb_seguro.cod_veiculo);
            return View(tb_seguro);
        }

        // POST: Seguros/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_seguro,cnh,rg,crv,crvl,cod_veiculo")] tb_seguro tb_seguro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_seguro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_veiculo = new SelectList(db.tb_veiculo, "cod_veiculo", "proprio_alugado", tb_seguro.cod_veiculo);
            return View(tb_seguro);
        }

        // GET: Seguros/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_seguro tb_seguro = db.tb_seguro.Find(id);
            if (tb_seguro == null)
            {
                return HttpNotFound();
            }
            return View(tb_seguro);
        }

        // POST: Seguros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_seguro tb_seguro = db.tb_seguro.Find(id);
            db.tb_seguro.Remove(tb_seguro);
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
