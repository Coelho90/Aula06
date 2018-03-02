using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.WEB.Models
{
    public class PlanoCadastroViewModel
    {
        [MinLength(3, ErrorMessage ="Por favor, informe no minimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Por favor, informe no maximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do plano.")]
        public string Nome{ get; set; }

        [MinLength(3, ErrorMessage = "Por favor, informe no minimo {1} caracteres.")]
        [MaxLength(250, ErrorMessage = "Por favor, informe no maximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a descrição do plano.")]
        public string Descricao { get; set; }


    }
}