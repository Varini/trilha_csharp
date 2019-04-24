using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace GerenciamentoContatos.Database
{
    public class DbConn : Smart.Database.DbConn
    {
        public override string BuildConnString()
        {
            this.ProviderName = "System.Data.SqlClient";
            return ConfigurationManager.AppSettings["ConnectionString"];
            
        }
    }
}