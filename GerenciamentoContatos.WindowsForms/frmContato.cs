using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GerenciamentoContatos.Model;
using GerenciamentoContatos.BLL;
using GerenciamentoContatos.View;
using System.Configuration;

namespace GerenciamentoContatos
{
    public partial class frmContato : Form
    {
        private HashSet<Control> camposVazios = new HashSet<Control>();        
        private int idContato = 0;
        private int idCidade = 0;
        private int idEstado = 0;

        private ContatoBLL contatoBLL = new ContatoBLL();
        private EstadoBLL estadoBLL = new EstadoBLL();
        private CidadeBLL cidadeBLL = new CidadeBLL();        

        public frmContato()
        {
            InitializeComponent();
        }

        private void carregarFrmContato(object sender, EventArgs e)
        {
            List<EstadoInfo> listaEstado = estadoBLL.Listar();

            ddlEstado.Items.Clear();

            foreach (EstadoInfo obj in listaEstado){
                ddlEstado.Items.Add(obj.DsEstado.Value + " - " + obj.DsUf.Value);            
            }
            ddlEstado.Text = "Selecione o estado...";            

            carregarDados(String.Empty); 

            foreach (DataGridViewBand band in grvContato.Columns)
            {
                band.ReadOnly = true;
            }
        }

        private void cadastrarContato(object sender, EventArgs e)
        {
            prepararValidacao();

            if (idContato != 0)
            {
                alterarContato();
            }
            else if (validarCampos() && camposVazios.Count == 0)
            {

                CidadeContatoEstadoView novoCadastro = new CidadeContatoEstadoView();                

                novoCadastro = prepararCadastro(false);                
                novoCadastro.Contato.CdCidade.Value = cidadeBLL.Get(cidadeBLL.Inserir(novoCadastro.Cidade)).CdCidade.Value;                
                contatoBLL.Inserir(novoCadastro.Contato);

                carregarDados(String.Empty);
                limparCadastro();
            }
        }

        private void alterarContato()
        {
            prepararValidacao();            

            if (validarCampos() && camposVazios.Count == 0)
            {

                DialogResult respostaUsuario = MessageBox.Show("Tem certeza que deseja alterar o contato?", "Confirma Alteração", MessageBoxButtons.YesNo);

                if (respostaUsuario == DialogResult.Yes)
                {
                    contatoBLL.Atualizar(idContato,prepararCadastro(true).Contato);
                    cidadeBLL.Atualizar(idCidade, prepararCadastro(true).Cidade);

                    carregarDados(String.Empty);
                    limparCadastro();
                }
            }
        }

        private void excluirContato(object sender, EventArgs e)
        {
            if (idContato != 0)
            {
                DialogResult respostaUsuario = MessageBox.Show("Tem certeza que deseja excluir o contato?", "Confirma Exclusão", MessageBoxButtons.YesNo);

                if (respostaUsuario == DialogResult.Yes)
                {
                    contatoBLL.Deletar(idContato);
                    cidadeBLL.Deletar(idCidade);

                    carregarDados(String.Empty);
                    limparCadastro();
                }
            }
            else
            {
                MessageBox.Show("Nenhum contato foi selecionado.");
            }

        }

        private void carregarDados(string busca)
        {
            List<ContatoInfo> listContato = contatoBLL.Listar();
            
            DataTable dtable = new DataTable();

            dtable.Columns.Add(new DataColumn("Nome"));
            dtable.Columns.Add(new DataColumn("E-mail"));
            dtable.Columns.Add(new DataColumn("Data de Nascimento"));
            dtable.Columns.Add(new DataColumn("CPF"));
            dtable.Columns.Add(new DataColumn("Cidade"));
            dtable.Columns.Add(new DataColumn("Estado"));
            dtable.Columns.Add(new DataColumn("Endereço"));
            dtable.Columns.Add(new DataColumn("CdCidade"));
            dtable.Columns.Add(new DataColumn("CdEstado"));
            dtable.Columns.Add(new DataColumn("CdContato"));

            object[] RowValues = new object[10];

            foreach (ContatoInfo obj in listContato)
            {
                CidadeInfo cidadeInfo = new CidadeInfo();
                EstadoInfo estadoInfo = new EstadoInfo();

                cidadeInfo = cidadeBLL.Get(obj.CdCidade.Value);
                estadoInfo = estadoBLL.Get(obj.CdEstado.Value);

                RowValues[0] = obj.DsNome.Value;
                RowValues[1] = obj.DsEmail.Value;
                RowValues[2] = obj.DtNascimento.Value;
                RowValues[3] = obj.DsCpf.Value;
                if (cidadeInfo != null) RowValues[4] = cidadeInfo.DsCidade.Value;
                if (estadoInfo != null) RowValues[5] = estadoInfo.DsUf.Value;
                RowValues[6] = obj.DsEndereco.Value;
                RowValues[7] = obj.CdCidade.Value;
                RowValues[8] = obj.CdEstado.Value;                
                RowValues[9] = obj.CdContato.Value;

                DataRow dRow;

                dRow = dtable.Rows.Add(RowValues);
            }

            if (!String.IsNullOrEmpty(busca))
            {
                DataTable tblFiltered = dtable.Clone();
                var rows = dtable.AsEnumerable().Where(row => row.Field<String>("Nome").Contains(busca))
                                                .OrderByDescending(row => row.Field<String>("Nome"));

                foreach (var row in rows)
                    tblFiltered.ImportRow(row);

                dtable = tblFiltered;
            }            

            dtable.AcceptChanges();
                        
            grvContato.DataSource = dtable;

            grvContato.Columns[7].Visible = false;
            grvContato.Columns[8].Visible = false;
            grvContato.Columns[9].Visible = false;
        }

        private CidadeContatoEstadoView prepararCadastro(bool alterar)
        {
            var contato = new CidadeContatoEstadoView();

            if (alterar)
            {
                contato.Contato.CdContato.Value = idContato;
                contato.Cidade.CdCidade.Value = idCidade;
                contato.Cidade.CdEstado.Value = idEstado;
            }

            contato.Contato.DsNome.Value = txtNome.Text;
            contato.Contato.DsEmail.Value = txtEmail.Text;
            DateTime data = DateTime.ParseExact(txtDtNasc.Text, "dd/MM/yyyy", null);
            contato.Contato.DtNascimento.Value = data;
            contato.Contato.DsCpf.Value = txtCPF.Text.Trim();
            contato.Contato.DsCpf.Value = contato.Contato.DsCpf.Value.Replace(",", "").Replace("-", "");
            contato.Contato.CdEstado.Value = ((ddlEstado.SelectedIndex)) + 1;
            contato.Contato.DsEndereco.Value = txtEndereco.Text;
            contato.Cidade.DsCidade.Value = txtCidade.Text;
            contato.Cidade.CdEstado.Value = ((ddlEstado.SelectedIndex)) + 1;

            return contato;
        }

        private void buscarCadastro(object sender, EventArgs e)
        {
            carregarDados(txtBusca.Text);
        }  

        private void acionarLimpar(object sender, EventArgs e)
        {
            limparCadastro();
        }

        private void limparCadastro() 
        {
            Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
            Controls.OfType<MaskedTextBox>().ToList().ForEach(t => t.Clear());

            List<EstadoInfo> listaEstado = estadoBLL.Listar();

            ddlEstado.Items.Clear();

            foreach (EstadoInfo obj in listaEstado)
            {
                ddlEstado.Items.Add(obj.DsEstado.Value + " - " + obj.DsUf.Value);
            }
            ddlEstado.Text = "Selecione o estado...";

            idContato = 0;
            idCidade = 0;
            idEstado = 0;
            btnExcluir.Visible = false;
        }

        private void prepararValidacao()
        {
            eprValidacao.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            txtNome.Tag = txtEmail.Tag = txtDtNasc.Tag = txtCPF.Tag = "Este campo é obrigatório.";

            validarTextBox(txtNome, EventArgs.Empty);
            validarTextBox(txtEmail, EventArgs.Empty);
            validarMaskedTextBox(txtDtNasc, EventArgs.Empty);
            validarMaskedTextBox(txtCPF, EventArgs.Empty);
        }        

        private void validarTextBox(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == String.Empty)
            {
                eprValidacao.SetError(textBox, (string)textBox.Tag);
                camposVazios.Add(textBox);
            }
            else
            {
                eprValidacao.SetError(textBox, null);
                camposVazios.Remove(textBox);
            }
        }

        private void validarMaskedTextBox(object sender, EventArgs e)
        {
            var maskedTextBox = sender as MaskedTextBox;
            if (!maskedTextBox.MaskFull)
            {
                eprValidacao.SetError(maskedTextBox, (string)maskedTextBox.Tag);
                camposVazios.Add(maskedTextBox);
            }
            else
            {
                eprValidacao.SetError(maskedTextBox, null);
                camposVazios.Remove(maskedTextBox);
                eprValidacao.SetError(maskedTextBox, null);
                camposVazios.Remove(maskedTextBox);
            }            
        }

        private bool validarCampos()
        {
            string mensagemValidacao = String.Empty;

            if (txtEmail.Text != String.Empty && !Validacao.ValidaEmail(txtEmail.Text))
            {
                mensagemValidacao += "E-mail inválido.\n";                
            }

            if (txtDtNasc.MaskFull && !Validacao.ValidaData(txtDtNasc.Text))
            {
                mensagemValidacao += "Data de Nascimento inválida.\n";
            }

            if (txtCPF.MaskFull && !Validacao.ValidaCPF(txtCPF.Text)) 
            {
                mensagemValidacao += "Número do CPF inválido.\n";                
            }

            if (mensagemValidacao != String.Empty)
            {
                MessageBox.Show(mensagemValidacao);
                mensagemValidacao = String.Empty;
                return false;
            }

            return true;
        }

        private void selecionarCelula(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idContato = Convert.ToInt32(grvContato.Rows[e.RowIndex].Cells[9].Value.ToString());
                idEstado = Convert.ToInt32(grvContato.Rows[e.RowIndex].Cells[8].Value.ToString());
                idCidade = Convert.ToInt32(grvContato.Rows[e.RowIndex].Cells[7].Value.ToString());                

                txtNome.Text = grvContato.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtEmail.Text = grvContato.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDtNasc.Text = grvContato.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCPF.Text = grvContato.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtCidade.Text = grvContato.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtEndereco.Text = grvContato.Rows[e.RowIndex].Cells[6].Value.ToString();

                ddlEstado.SelectedIndex = System.Convert.ToInt32(grvContato.Rows[e.RowIndex].Cells[8].Value) - 1;

                btnExcluir.Visible = true;
            }
            catch 
            {
                MessageBox.Show("Selecione um contato!", "Aviso");
            }
        }
    }
}