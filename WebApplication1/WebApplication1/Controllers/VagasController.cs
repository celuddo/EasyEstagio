using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyEstagio.Models;

namespace EasyEstagio.Controllers
{
    public class VagasController : Controller
    {
        private VagasDBContext db = new VagasDBContext();

        // GET: Vagas
        public ActionResult Index()
        {
            return View(db.Vagas.ToList());
        }

        // GET: Vagas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vagas vagas = db.Vagas.Find(id);
            if (vagas == null)
            {
                return HttpNotFound();
            }
            return View(vagas);
        }

        // GET: Vagas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vagas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Atividades,PreRequisitos,CargaHoraria,Beneficios,PalavrasChave")] Vagas vagas)
        {
            if (ModelState.IsValid)
            {
                db.Vagas.Add(vagas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vagas);
        }

        // GET: Vagas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vagas vagas = db.Vagas.Find(id);
            if (vagas == null)
            {
                return HttpNotFound();
            }
            return View(vagas);
        }

        // POST: Vagas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Atividades,PreRequisitos,CargaHoraria,Beneficios,PalavrasChave")] Vagas vagas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vagas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vagas);
        }

        // GET: Vagas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vagas vagas = db.Vagas.Find(id);
            if (vagas == null)
            {
                return HttpNotFound();
            }
            return View(vagas);
        }

        // POST: Vagas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vagas vagas = db.Vagas.Find(id);
            db.Vagas.Remove(vagas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Pesquisa()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Pesquisa(string texto)
        {
            return View(db.Vagas.Where(x => x.Nome.Contains(texto)).OrderBy(x => x.Nome));
        }

        public ActionResult ConsultarVagas()
        {
            return View();
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
