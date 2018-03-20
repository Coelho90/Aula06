using Projeto.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.WEB.Models
{
    public class ClienteCadastroViewModel
    {

        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres")]
        [Required(ErrorMessage = "Por favor, informe o nome do cliente")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um endereço de email válido")]
        [Required(ErrorMessage = "Por favor, informe o email do cliente")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe o sexo do cliente")]
        public Sexo Sexo { get; set; }

        [Required(ErrorMessage = "Por favor, informe o estado civil do cliente")]
        public EstadoCivil EstadoCivil { get; set; }

        [Required(ErrorMessage = "Por favor, selecione o plano do cliente.")]
        public int IdPlano { get; set; }

        public List<SelectListItem> ListagemDePlanos { get; set; }
    }
}