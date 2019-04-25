using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Smart.Database;
using Smart.Model;

namespace GerenciamentoContatos
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            BusinessObject.DbConnAssemblyName = "GerenciamentoContatos.Database";
            BusinessObject.DbConnClassPath =    "GerenciamentoContatos.Database.DbConn";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmContato());
        }
    }
}
