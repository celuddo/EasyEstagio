﻿using System;
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
    public class EstudantesController : Controller
    {
        private EstudantesDBContext db = new EstudantesDBContext();

        // GET: Estudantes
        public ActionResult Index()
        {
            return View(db.Estudantes.ToList());
        }

        // GET: Estudantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudantes estudantes = db.Estudantes.Find(id);
            if (estudantes == null)
            {
                return HttpNotFound();
            }
            return View(estudantes);
        }

        // GET: Estudantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudantes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Senha,Endereço,Instituição,Curso,Semestre,EstáProcurandoVagas")] Estudantes estudantes)
        {
            if (ModelState.IsValid)
            {
                db.Estudantes.Add(estudantes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estudantes);
        }

        // GET: Estudantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudantes estudantes = db.Estudantes.Find(id);
            if (estudantes == null)
            {
                return HttpNotFound();
            }
            return View(estudantes);
        }

        // POST: Estudantes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Senha,Endereço,Instituição,Curso,Semestre,EstáProcurandoVagas")] Estudantes estudantes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudantes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudantes);
        }

        // GET: Estudantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudantes estudantes = db.Estudantes.Find(id);
            if (estudantes == null)
            {
                return HttpNotFound();
            }
            return View(estudantes);
        }

        // POST: Estudantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estudantes estudantes = db.Estudantes.Find(id);
            db.Estudantes.Remove(estudantes);
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
