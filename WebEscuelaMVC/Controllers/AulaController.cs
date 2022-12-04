using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEscuelaMVC.Data;
using WebEscuelaMVC.Models;

namespace WebEscuelaMVC.Controllers
{
    public class AulaController : Controller
    {
        private EscuelaDBContext context = new EscuelaDBContext();
        
        public ActionResult Index()
        {
            return View("Index", context.Aulas.ToList());
        }

        public ActionResult Create()
        {
            Aula newAula = new Aula();
            return View("Create", newAula);
        }

        [HttpPost]
        public ActionResult Create(Aula aula)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", aula);
            }
            context.Aulas.Add(aula);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Aula aula = context.Aulas.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            return View("Details", aula);
        }

        public ActionResult Edit(int id)
        {
            Aula aula = context.Aulas.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            return View("Edit", aula);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit([Bind(Include = "AulaId,Numero,Estado")] Aula aula)
        {
            if (ModelState.IsValid)
            {
                context.Entry(aula).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", aula);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Aula aula = context.Aulas.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            return View("Delete", aula);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Aula aula = context.Aulas.Find(id);
            context.Aulas.Remove(aula);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult ListarPorEstado(string estado)
        {

            return View("Index", BuscarPorEstado(estado));
        }

        [NonAction]
        public List<Aula> BuscarPorEstado(string estado)
        {
            List<Aula> listXEstado = new List<Aula>();
            listXEstado = (from a in context.Aulas where a.Estado.ToLower() == estado.ToLower() select a).ToList();
            return listXEstado;
        }


        public ActionResult TraerPorNumero(int numero)
        {
            if (BuscaPorNumero(numero) == null)
            {
                return HttpNotFound();
            }
            return View("Details", BuscaPorNumero(numero));
        }


        [NonAction]
        public Aula BuscaPorNumero(int numero)
        {
            Aula aulaXNumero = new Aula();
            aulaXNumero = (from a in context.Aulas where a.Numero == numero select a).SingleOrDefault();
            return aulaXNumero;
        }

        

    }
}