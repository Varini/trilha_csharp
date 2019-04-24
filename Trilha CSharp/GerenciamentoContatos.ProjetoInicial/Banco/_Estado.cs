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
    public class _Estado
    {
        private string connectionString;

        public _Estado()
        {
            connectionString = ConfigurationManager.AppSettings["SqlConnection"];
        }

        public DataTable Buscar(string dsEstado)
        {
            using (SqlConnection connection = new SqlConnection(
               connectionString))
            {
                string queryString = "SELECT * FROM ESTADO WHERE ds_estado like '%" + dsEstado + "%'";
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
