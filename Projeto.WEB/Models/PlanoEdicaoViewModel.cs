using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.WEB.Models
{
    public class PlanoEdicaoViewModel
    {

        [Required(ErrorMessage = "Informe o id do plano.")]
        public int IdPlano { get; set; }

        [MinLength(3, ErrorMessage ="Por favor, informe no minimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage ="Por favor, infrome no máximo {1} caracteres. ")]
        [Required(ErrorMessage = "Por favor, informe o nome do plano.")]
        public String Nome { get; set; }

        [MinLength(3, ErrorMessage = "Por favor, informe no minimo {1} caracteres.")]
        [MaxLength(250, ErrorMessage = "Por favor, infrome no máximo {1} caracteres. ")]
        [Required(ErrorMessage = "Por favor, informe a descrição do plano.")]
        public string Descricao { get; set; }








    }

}