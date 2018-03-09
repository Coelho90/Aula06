using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Projeto.Entidades;

namespace Projeto.DAL
{
    public class PlanoRepositorio : Conexao
    {
        public void Insert(Plano p)
        {

            OpenConnection();

            string query = "insert into Plano(Nome, Descricao) " + "values(@Nome, @Descricao)";


            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", p.Nome);
            cmd.Parameters.AddWithValue("@Descricao", p.Descricao);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }


        public void Update(Plano p)
        {
            OpenConnection();

            string query = "update Plano set Nome = @Nome, Descricao = @Descricao " + "where IdPlano = @IdPlano";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdPlano", p.IdPlano);
            cmd.Parameters.AddWithValue("@Nome", p.Nome);
            cmd.Parameters.AddWithValue("@Descricao", p.Descricao);
            cmd.ExecuteNonQuery();

            CloseConnection();

        }


        public void Delete(int idPlano)
        {

            OpenConnection();

            string query = "delete from Plano where IdPlano = @IdPlano";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdPlano", idPlano);
            cmd.ExecuteNonQuery();

        }

        public List<Plano> FindAll()
        {
            OpenConnection();

            string query = "select * from Plano";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Plano> lista = new List<Plano>();

            while (dr.Read())
            {
                Plano p = new Plano();

                p.IdPlano = Convert.ToInt32(dr["IdPlano"]);
                p.Nome = Convert.ToString(dr["Nome"]);
                p.Descricao = Convert.ToString(dr["Descricao"]);

                lista.Add(p);
            }

            CloseConnection();
            return lista;

        }


        public Plano FindById(int idPlano)
        {
            OpenConnection();

            string query = "select * from Plano where IdPlano = @IdPlano";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdPlano", idPlano);
            dr = cmd.ExecuteReader();

            Plano p = null;

            if (dr.Read())
            {
                p = new Plano();

                p.IdPlano = Convert.ToInt32(dr["IdPlano"]);
                p.Nome = Convert.ToString(dr["Nome"]);
                p.Descricao = Convert.ToString(dr["Descricao"]);
            }

            CloseConnection();
            return p;
        }


    }
}
