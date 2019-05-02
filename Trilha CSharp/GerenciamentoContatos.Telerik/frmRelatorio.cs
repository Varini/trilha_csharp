using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace GerenciamentoContatos
{
    public partial class frmRelatorio : Telerik.WinControls.UI.RadForm
    {
        public frmRelatorio()
        {
            InitializeComponent();
        }

        public void CarregarRelatorio(Telerik.Reporting.Report rpt) 
        {
            rpvContatos.ReportSource = rpt;            

            rpvContatos.Show();

            rpvContatos.RefreshReport();        
        }

    }
}
