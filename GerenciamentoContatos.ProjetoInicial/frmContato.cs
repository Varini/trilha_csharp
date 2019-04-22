using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Evento;
using Modelo;
using System.Configuration;


namespace GerenciamentoContatos
{
    public partial class frmContato : Form
    {

        private HashSet<Control> camposVazios = new HashSet<Control>();
        private int idContato = 0;

        public frmContato()
        {
            InitializeComponent();            
        }

        private void carregarFrmContato(object sender, EventArgs e)
        {

            List<EstadoModelo> listEstado = Estado.Buscar(String.Empty);

            ddlEstado.DataSource = listEstado;
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
                Contato.Gravar(prepararContato(false));

                carregarDados(String.Empty);
                limparCadastro(null, null);
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
                    Contato.Atualizar(prepararContato(true));

                    carregarDados(String.Empty);
                    limparCadastro(null, null);
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
                    Contato.Deletar(idContato.ToString());

                    carregarDados(String.Empty);
                    limparCadastro(null, null);
                }
            }
            else
            {
                MessageBox.Show("Nenhum contato foi selecionado.");
            }

        }

        private void carregarDados(string busca)
        {
            List<ContatoModelo> listContato = Contato.Buscar(busca);

            grvContato.DataSource = listContato;

            grvContato.Columns[0].Visible = false;
            grvContato.Columns[1].HeaderText = "Nome";
            grvContato.Columns[2].HeaderText = "E-mail";
            grvContato.Columns[3].HeaderText = "Data de Nascimento";
            grvContato.Columns[4].HeaderText = "CPF";
            grvContato.Columns[5].Visible = false;
            grvContato.Columns[6].HeaderText = "Cidade";
            grvContato.Columns[7].Visible = false;
            grvContato.Columns[8].HeaderText = "Estado";
            grvContato.Columns[9].HeaderText = "Endereço";            
        }

        private ContatoModelo prepararContato(bool alterar)
        {
            var contato = new ContatoModelo();

            if (alterar) contato.CdContato = idContato.ToString();

            contato.Nome = txtNome.Text;
            contato.Email = txtEmail.Text;
            contato.DtNasc = txtDtNasc.Text;
            contato.CPF = txtCPF.Text.Trim();
            contato.CPF = contato.CPF.Replace(",", "").Replace("-", "");
            contato.UF = txtEndereco.Text;
            contato.CdEstado = ((ddlEstado.SelectedIndex) + 1).ToString();
            contato.Endereco = txtEndereco.Text;
            contato.Cidade = txtCidade.Text;

            return contato;
        }

        private void buscarPorNome(object sender, EventArgs e)
        {
            carregarDados(txtBusca.Text);
        }  

        private void limparCadastro(object sender, EventArgs e)
        {
            Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
            Controls.OfType<MaskedTextBox>().ToList().ForEach(t => t.Clear());

            ddlEstado.DataSource = Estado.Buscar(String.Empty);
            ddlEstado.Text = "Selecione o estado...";

            idContato = 0;
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
                idContato = Convert.ToInt32(grvContato.Rows[e.RowIndex].Cells[0].Value);
                txtNome.Text = grvContato.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtEmail.Text = grvContato.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDtNasc.Text = grvContato.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtCPF.Text = grvContato.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtCidade.Text = grvContato.Rows[e.RowIndex].Cells[6].Value.ToString();
                ddlEstado.SelectedIndex = System.Convert.ToInt32(grvContato.Rows[e.RowIndex].Cells[7].Value) - 1;
                txtEndereco.Text = grvContato.Rows[e.RowIndex].Cells[9].Value.ToString();

                btnExcluir.Visible = true;
            }
            catch 
            {
                grvContato.Focus();
            }
        }

        //private void selecionarContato(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    idContato = Convert.ToInt32(grvContato.Rows[e.RowIndex].Cells[0].Value);
        //    txtNome.Text = grvContato.Rows[e.RowIndex].Cells[1].Value.ToString();
        //    txtEmail.Text = grvContato.Rows[e.RowIndex].Cells[2].Value.ToString();
        //    txtDtNasc.Text = grvContato.Rows[e.RowIndex].Cells[3].Value.ToString();
        //    txtCPF.Text = grvContato.Rows[e.RowIndex].Cells[4].Value.ToString();
        //    txtCidade.Text = grvContato.Rows[e.RowIndex].Cells[6].Value.ToString();
        //    ddlEstado.SelectedIndex = System.Convert.ToInt32(grvContato.Rows[e.RowIndex].Cells[7].Value) - 1;
        //    txtEndereco.Text = grvContato.Rows[e.RowIndex].Cells[9].Value.ToString();

        //    btnExcluir.Visible = true;
        //}

    }
}