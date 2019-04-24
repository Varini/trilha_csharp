using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Banco
{
    public class Contato
    {
        private string connectionString;

        public Contato()
        {
            connectionString = ConfigurationManager.AppSettings["SqlConnection"];
        }

        public void Gravar(string nome, string email, string dtNasc, string cpf, string cdCidade, string dsCidade, string cdEstado, string endereco)
        {

            string ultimoCdCidade = String.Empty;

            using (SqlConnection connection = new SqlConnection(
               connectionString))
            {
                string queryString = "INSERT INTO CIDADE (ds_cidade, cd_estado) VALUES (@dscidade, @cdestado);";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@cdestado", cdEstado);
                command.Parameters.AddWithValue("@dscidade", dsCidade);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }

            using (SqlConnection connection = new SqlConnection(
               connectionString))
            {
                string queryString = "SELECT TOP 1 cd_cidade FROM CIDADE ORDER BY cd_cidade DESC";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);                

                foreach (DataRow dr in table.Rows)
                {
                    ultimoCdCidade = dr["cd_cidade"].ToString();
                }
            }

            using (SqlConnection connection = new SqlConnection(
               connectionString))
            {
                string queryString = "INSERT INTO " + this.GetType().Name + "(ds_nome, ds_email, dt_nascimento, ds_cpf, cd_cidade, cd_estado, ds_endereco) VALUES (@nome, @email, @dtnasc, @cpf, @cdcidade, @cdestado, @endereco);";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@nome", nome);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@dtnasc", DateTime.ParseExact(dtNasc, "dd/MM/yyyy", null));
                command.Parameters.AddWithValue("@cpf", cpf);
                command.Parameters.AddWithValue("@cdcidade", ultimoCdCidade);
                command.Parameters.AddWithValue("@cdestado", cdEstado);
                command.Parameters.AddWithValue("@endereco", endereco);
                command.Connection.Open();
                command.ExecuteNonQuery();

                command = new SqlCommand(queryString, connection);
            }
        }

        public void Atualizar(string cdContato, string nome, string email, string dtNasc, string cpf, string cdCidade, string dsCidade, string cdEstado, string endereco)
        {

            string ultimoCdCidade = String.Empty;

            using (SqlConnection connection = new SqlConnection(
               connectionString))
            {
                string queryString = "INSERT INTO CIDADE (ds_cidade, cd_estado) VALUES (@dscidade, @cdestado);";
                SqlCommand command = new SqlCommand(queryString, connection);                
                command.Parameters.AddWithValue("@cdestado", cdEstado);
                command.Parameters.AddWithValue("@dscidade", dsCidade);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }

            using (SqlConnection connection = new SqlConnection(
               connectionString))
            {
                string queryString = "SELECT TOP 1 cd_cidade FROM CIDADE ORDER BY cd_cidade DESC";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                foreach (DataRow dr in table.Rows)
                {
                    ultimoCdCidade = dr["cd_cidade"].ToString();
                }
            }

            using (SqlConnection connection = new SqlConnection(
               connectionString))
            {
                string queryString = "UPDATE " + this.GetType().Name + " SET ds_nome=@nome, ds_email=@email, dt_nascimento=@dtnasc, ds_cpf=@cpf, cd_cidade=@cdcidade, cd_estado=@cdestado, ds_endereco=@endereco WHERE cd_contato=@id";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", cdContato);
                command.Parameters.AddWithValue("@nome", nome);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@dtnasc", DateTime.ParseExact(dtNasc, "dd/MM/yyyy", null));
                command.Parameters.AddWithValue("@cpf", cpf);
                command.Parameters.AddWithValue("@cdcidade", ultimoCdCidade);
                command.Parameters.AddWithValue("@cdestado", cdEstado);
                command.Parameters.AddWithValue("@endereco", endereco);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Deletar(string cdContato)
        {
            using (SqlConnection connection = new SqlConnection(
               connectionString))
            {
                string queryString = "DELETE FROM " + this.GetType().Name + " WHERE cd_contato=@id";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", cdContato);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public DataTable Buscar(string nome)
        {
            using (SqlConnection connection = new SqlConnection(
               connectionString))
            {
                string  queryString =   "SELECT CONTATO.*, convert(varchar, dt_nascimento ,103) as 'dt_nascimento_formatada', CIDADE.ds_cidade, ESTADO.ds_uf ";
                        queryString +=  "FROM CONTATO ";
                        queryString +=  "LEFT JOIN CIDADE ON CIDADE.cd_cidade = CONTATO.cd_cidade ";
                        queryString +=  "LEFT JOIN ESTADO ON ESTADO.cd_estado = CONTATO.cd_estado ";
                        queryString +=  "WHERE ds_nome like '%" + nome + "%'";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }
        }
    }
}
