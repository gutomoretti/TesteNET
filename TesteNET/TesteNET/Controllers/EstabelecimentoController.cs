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
    public class EstabelecimentoController : Controller
    {
        private FitCardDataModel db = new FitCardDataModel();
        private string mensagemController = "MensagemRetorno";

        // GET: Estabelecimento
        public ActionResult Index(int? p)
        {
            //var estabelecimentoes = db.Estabelecimentoes.Include(e => e.Categoria).Include(e => e.Estado);
            //return View(estabelecimentoes.ToList());

            var listaEstabelecimento = from e in db.Estabelecimentos
                                       orderby e.RazaoSocial ascending
                                       select e;

            //Definição de itens por página e pagina atual
            int itensPagina = 10;
            int numeroPagina = (p ?? 1);

            // Retorna lista para a view
            return View(listaEstabelecimento.ToPagedList(numeroPagina, itensPagina));
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

            Estabelecimento estabelecimento = db.Estabelecimentos.Find(ID);
            bool statusAtivo = Convert.ToBoolean(ativo);

            estabelecimento.Status = statusAtivo;

            db.Entry(estabelecimento).CurrentValues.SetValues(estabelecimento);
            db.SaveChanges();

            return new EmptyResult();
        }

        // GET: Estabelecimento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabelecimento estabelecimento = db.Estabelecimentos.Find(id);
            if (estabelecimento == null)
            {
                return HttpNotFound();
            }
            return View(estabelecimento);
        }

        // GET: Estabelecimento/Create
        public ActionResult Create()
        {
            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "Nome");
            // Carrega ViewBag com lista de estados e cidades
            ViewBag.IDEstado = new SelectList(db.Estados.OrderBy(o => o.nome), "IDEstado", "nome");
            ViewBag.IDCidade = new SelectList(db.Cidades.Where(w => w.IDCidade == 0).OrderBy(o => o.nome), "IDCidade", "nome");
            return View();
        }

        // POST: Estabelecimento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                estabelecimento.DataCadastro = DateTime.Now;
                estabelecimento.Status = true;
                db.Estabelecimentos.Add(estabelecimento);
                db.SaveChanges();

                TempData.Add(mensagemController, string.Format("O estabelecimento \"{0}\" foi incluído com sucesso!", estabelecimento.NomeFantasia));
                TempData.Add("MensagemTipo", "success");

                return RedirectToAction("Index");
            }

            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "Nome", estabelecimento.IDCategoria);
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "nome", estabelecimento.IDCidade);
            ViewBag.IDEstado = new SelectList(db.Estados, "IDEstado", "nome", estabelecimento.IDEstado);

            return View(estabelecimento);
        }

        // GET: Estabelecimento/Edit/5
        public ActionResult Edit(string id)
        {
            // Verifica se foi enviado o ID
            if (string.IsNullOrEmpty(id))
            {
                TempData.Add(mensagemController, "Não foi possível acessar o formulário de edição: nenhuma estabelecimento informado para consulta");
                TempData.Add("MensagemTipo", "warning");

                return RedirectToAction("Index");
            }

            int ID = Convert.ToInt32(id);

            Estabelecimento estabelecimento = db.Estabelecimentos.Find(ID);
            if (estabelecimento == null)
            {
                TempData.Add(mensagemController, "Não foi possível acessar o formulário de edição: nenhum estabelecimento foi encontrado");
                TempData.Add("MensagemTipo", "warning");

                return RedirectToAction("Index");
            }

            int IDEstado = (estabelecimento.IDCidade > 0) ? db.Cidades.Find(estabelecimento.IDCidade).IDEstado : 0;
            ViewBag.IDEstado = new SelectList(db.Estados.OrderBy(o => o.uf), "IDEstado", "Nome", IDEstado);
            ViewBag.IDCidade = new SelectList(db.Cidades.Where(w => w.IDEstado == IDEstado).OrderBy(o => o.nome), "IDCidade", "Nome", estabelecimento.IDCidade);

            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "Nome", estabelecimento.IDCategoria);
            //ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "nome", estabelecimento.IDCidade);
            //ViewBag.IDEstado = new SelectList(db.Estados, "IDEstado", "nome", estabelecimento.IDEstado);
            return View(estabelecimento);
        }

        // POST: Estabelecimento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDEstabelecimento,IDCategoria,RazaoSocial,NomeFantasia,CNPJ,Email,Endereco,IDEstado,IDCidade,Telefone,DataCadastro,Status")] Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estabelecimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "Nome", estabelecimento.IDCategoria);
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "nome", estabelecimento.IDCidade);
            ViewBag.IDEstado = new SelectList(db.Estados, "IDEstado", "nome", estabelecimento.IDEstado);
            return View(estabelecimento);
        }

        // GET: Estabelecimento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabelecimento estabelecimento = db.Estabelecimentos.Find(id);
            if (estabelecimento == null)
            {
                return HttpNotFound();
            }
            return View(estabelecimento);
        }

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

            // Descriptografa o ID do usuário
            int ID = Convert.ToInt32(id);

            Estabelecimento estabelecimento = db.Estabelecimentos.Find(id);
            db.Estabelecimentos.Remove(estabelecimento);
            db.SaveChanges();

            return new EmptyResult();
        }

        /// <summary>
        /// Recupera as cidades de um determinado estado
        /// </summary>
        /// <param name="IDEstado">int IDEstado</param>
        /// <returns>
        /// Lista JSON com as cidades de um determinado estado
        /// </returns>
        [HttpPost]
        public ActionResult SelecionarCidadesPorEstado(int? IDEstado)
        {
            // Verifica se foi enviado o ID do estado   
            if (IDEstado == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Realiza um SELECT na tabela "cidade" para listar as cidades de um determinado estado
            var cidades = from c in db.Cidades
                          where c.IDEstado == IDEstado
                          orderby c.nome
                          select new cidadelista() { IDCidade = c.IDCidade, Nome = c.nome };

            // Retorna um JSON com o resultado do SELECT
            return Json(cidades, JsonRequestBehavior.AllowGet);
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
