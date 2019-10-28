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
    public class AuthController : Controller
    {
        private bd_gestmoveEntities db = new bd_gestmoveEntities();

        // GET: Auth
        public ActionResult Index([Bind(Include = "ID, usuario, senha, nv_user")] tb_login tb_login)
        {
            return View(db.tb_login.ToList());
        }

        // GET: Auth/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_login tb_login = db.tb_login.Find(id);
            if (tb_login == null)
            {
                return HttpNotFound();
            }
            return View(tb_login);
        }

        // GET: Auth/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auth/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, usuario, senha, nv_user")] tb_login tb_login)
        {
            if (ModelState.IsValid)
            {
                db.tb_login.Add(tb_login);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_login);
        }

        // GET: Auth/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_login tb_login = db.tb_login.Find(id);
            if (tb_login == null)
            {
                return HttpNotFound();
            }
            return View(tb_login);
        }

        // POST: Auth/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,usuario,senha,nv_user")] tb_login tb_login)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_login).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_login);
        }

        // GET: Auth/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_login tb_login = db.tb_login.Find(id);
            if (tb_login == null)
            {
                return HttpNotFound();
            }
            return View(tb_login);
        }

        // POST: Auth/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_login tb_login = db.tb_login.Find(id);
            db.tb_login.Remove(tb_login);
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
