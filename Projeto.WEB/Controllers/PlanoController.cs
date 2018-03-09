using Projeto.Entidades;
using Projeto.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.DAL;

namespace Projeto.WEB.Controllers
{
    public class PlanoController : Controller
    {
        // GET: Plano
        public ActionResult Cadastro()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Cadastro(PlanoCadastroViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    Plano p = new Plano();

                    p.Nome = model.Nome;
                    p.Descricao = model.Descricao;

                    PlanoRepositorio rep = new PlanoRepositorio();
                    rep.Insert(p);

                    ViewBag.Mensagem = $"Plano {p.Nome}, cadastrado com sucesso.";

                    ModelState.Clear();

                }

            }
            catch (Exception e)
            {

                ViewBag.Mensagem = "Ocorreu um erro: " + e.Message;
            }
            return View();
        }


        public ActionResult Consulta()
        {

            List<PlanoConsultaViewModel> lista = new List<PlanoConsultaViewModel>();

            try
            {
                PlanoRepositorio rep = new PlanoRepositorio();
                foreach (Plano p in rep.FindAll())
                {
                    PlanoConsultaViewModel model = new PlanoConsultaViewModel();
                    model.IdPlano = p.IdPlano;
                    model.Nome = p.Nome;
                    model.Descricao = p.Descricao;

                    lista.Add(model);
                }
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = "Erro " + e.Message;

            }
            
            return View(lista);
        }

        
        public ActionResult Edicao(int idPlano)
        {

            PlanoEdicaoViewModel model = new PlanoEdicaoViewModel();

            try
            {
                PlanoRepositorio rep = new PlanoRepositorio();
                Plano p = rep.FindById(idPlano);

                model.IdPlano = p.IdPlano;
                model.Nome = p.Nome;
                model.Descricao = p.Descricao;
            }
            catch(Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }


            return View(model);
        }

        [HttpPost]
        public ActionResult Edicao(PlanoEdicaoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Plano p = new Plano();

                    p.IdPlano = model.IdPlano;
                    p.Nome = model.Nome;
                    p.Descricao = model.Descricao;

                    PlanoRepositorio rep = new PlanoRepositorio();
                    rep.Update(p);

                    ViewBag.Mensagem = $"Plano {p.Nome}, atualizado com sucesso.";

                }
            }
            catch (Exception e)
            {

                ViewBag.Mensagem = "Ocorreu um erro: " + e.Message;
            }

            return View();
        }


    }
}