using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entidades.Tipos;

namespace Projeto.Entidades
{
    public class Cliente
    {
        public int IdCliente{ get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }

        public Plano  Plano { get; set; }

       

        public Cliente()
        {

        }

        public Cliente(int idCliente, string nome, string email, DateTime dataCadastro, Sexo sexo, EstadoCivil estadoCivil)
        {
            IdCliente = idCliente;
            Nome = nome;
            Email = email;
            DataCadastro = dataCadastro;
            Sexo = sexo;
            EstadoCivil = estadoCivil;
        }

        public override string ToString()
        {
            return $"Id: {IdCliente}, Nome: {Nome}, Email: {Email}, Sexo: {Sexo}, Estado Civil: {EstadoCivil}, Data de Cadastro: {DataCadastro}";
        }

    }

}
