using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TesteNET.Models;

namespace TesteNET.Controllers
{
    public class CategoriaController : Controller
    {
        private FitCardDataModel db = new FitCardDataModel();
        private string mensagemController = "MensagemRetorno";

        // GET: Categoria
        public ActionResult Index(int? p)
        {
            //var estabelecimentoes = db.Estabelecimentoes.Include(e => e.Categoria).Include(e => e.Estado);
            //return View(estabelecimentoes.ToList());

            var categorias = from e in db.Categorias
                                       orderby e.Nome ascending
                                       select e;

            //Definição de itens por página e pagina atual
            int itensPagina = 10;
            int numeroPagina = (p ?? 1);

            // Retorna lista para a view
            return View(categorias.ToPagedList(numeroPagina, itensPagina));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ativo"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ativo(string id, string ativo)
        {
            // Verifica se foi enviado o ID
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int ID = Convert.ToInt32(id);

            Categoria categoria = db.Categorias.Find(ID);
            bool statusAtivo = Convert.ToBoolean(ativo);

            categoria.Status = statusAtivo;

            db.Entry(categoria).CurrentValues.SetValues(categoria);
            db.SaveChanges();

            return new EmptyResult();
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoria.Status = true;
                db.Categorias.Add(categoria);
                db.SaveChanges();

                TempData.Add(mensagemController, string.Format("A categoria \"{0}\" foi incluída com sucesso!", categoria.Nome));
                TempData.Add("MensagemTipo", "success");

                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria).State = EntityState.Modified;
                db.SaveChanges();

                TempData.Add(mensagemController, string.Format("Os dados da categoria \"{0}\" foram atualizados com sucesso!", categoria.Nome));
                TempData.Add("MensagemTipo", "success");

                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            // Verifica se foi enviado o ID
            if (String.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int ID = Convert.ToInt32(id);

            Categoria categoria = db.Categorias.Find(ID);
            db.Categorias.Remove(categoria);
            db.SaveChanges();

            return new EmptyResult();
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
