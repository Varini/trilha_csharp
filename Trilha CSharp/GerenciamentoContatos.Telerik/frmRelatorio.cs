
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
