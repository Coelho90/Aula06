using Projeto.Entidades;
using Projeto.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.DAL
{
    public class ClienteRepositorio : Conexao
    {
        public void Insert (Cliente c)
        {
            OpenConnection();

            string query = $"insert into Cliente(Nome, Email, Sexo, EstadoCivil, DataCadastro, IdPlano) values (@Nome, @Email, @Sexo, @EstadoCivil, @DataCadastro, @IdPlano)";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", c.Nome);
            cmd.Parameters.AddWithValue("@Email", c.Email);
            cmd.Parameters.AddWithValue("@Sexo", c.Sexo.ToString());
            cmd.Parameters.AddWithValue("@EstadoCivil", c.EstadoCivil.ToString());
            cmd.Parameters.AddWithValue("@DataCadastro", c.DataCadastro);
            cmd.Parameters.AddWithValue("@IdPlano", c.Plano.IdPlano);
            cmd.ExecuteNonQuery();

            CloseConnection();
            
        }



        public List<Cliente> FindAll()
        {
            OpenConnection();

            string query = "select c.IdCliente, c.Nome, c.Email, c.Sexo, c.EstadoCivil, c.DataCadastro, p.IdPlano, p.Nome as NomePlano from Cliente c inner join Plano p on p.IdPlano = c.Idplano";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Cliente> lista = new List<Cliente>();

            while (dr.Read())
            {
                Cliente c = new Cliente();
                c.Plano = new Plano();

                c.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                c.Nome = Convert.ToString(dr["Nome"]);
                c.Email = Convert.ToString(dr["Email"]);
                c.Sexo = (Sexo) Enum.Parse(typeof(Sexo), Convert.ToString(dr["Sexo"]));
                c.EstadoCivil = (EstadoCivil)Enum.Parse(typeof(EstadoCivil), Convert.ToString(dr["EstadoCivil"]));
                c.DataCadastro = Convert.ToDateTime(dr["DataCadastro"]);
                c.Plano.IdPlano = Convert.ToInt32(dr["IdPlano"]);
                c.Plano.Nome = Convert.ToString(dr["NomePlano"]);

                lista.Add(c);                    

            }

            CloseConnection();

            return lista;


        }
    }
}
