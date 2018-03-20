using Projeto.DAL;
using Projeto.Entidades;
using Projeto.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.WEB.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Cadastro()
        {

            ClienteCadastroViewModel viewModel = new ClienteCadastroViewModel();
            viewModel.ListagemDePlanos = ObterPlanos();
            
            return View(viewModel);
        }

        
        [HttpPost]
        public ActionResult Cadastro(ClienteCadastroViewModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    Cliente c = new Cliente();
                    c.Plano = new Plano();

                    c.Nome = model.Nome;
                    c.Email = model.Email;
                    c.Sexo = model.Sexo;
                    c.EstadoCivil = model.EstadoCivil;
                    c.DataCadastro = DateTime.Now;
                    c.Plano.IdPlano = model.IdPlano;

                    ClienteRepositorio rep = new ClienteRepositorio();
                    rep.Insert(c);

                    ViewBag.Mensagem = $"Cliente {c.Nome}, cadastro com sucesso.";
                    ModelState.Clear();

                }
                catch (Exception e)
                {

                    ViewBag.Mensagem = "Ocorreu um erro: " + e.Message;
                }
            }

            ClienteCadastroViewModel viewModel = new ClienteCadastroViewModel();
            viewModel.ListagemDePlanos = ObterPlanos();

            return View(viewModel);
        }


        public ActionResult Consulta()
        {
            List<ClienteConsultaViewModel> lista = new List<ClienteConsultaViewModel>();

            try
            {

                ClienteRepositorio rep = new ClienteRepositorio();
                foreach (Cliente c in rep.FindAll())
                {
                    ClienteConsultaViewModel model = new ClienteConsultaViewModel();
                    model.IdCliente = c.IdCliente;
                    model.Nome = c.Nome;
                    model.Email = c.Email;
                    model.Sexo = c.Sexo;
                    model.EstadoCivil = c.EstadoCivil;
                    model.DataCadastro = c.DataCadastro;
                    model.IdPlano = c.Plano.IdPlano;
                    model.NomePlano = c.Plano.Nome;

                    lista.Add(model);
                }
                
            }
            catch (Exception e)
            {

                ViewBag.Mensagem = e.Message;
            }


            return View(lista);
        }


        private List<SelectListItem> ObterPlanos()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            PlanoRepositorio rep = new PlanoRepositorio();
            foreach (Plano p in rep.FindAll())
            {
                SelectListItem item = new SelectListItem();
                item.Value = p.IdPlano.ToString();
                item.Text = p.Nome;

                lista.Add(item);
            }
            return lista;

        }
    }

    
}
