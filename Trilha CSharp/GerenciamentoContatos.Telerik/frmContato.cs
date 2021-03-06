﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GerenciamentoContatos.Model;
using GerenciamentoContatos.BLL;
using GerenciamentoContatos.View;
using Telerik.WinControls.UI;

namespace GerenciamentoContatos
{
    public partial class frmContato : Form
    {
        #region Gerenciamento de Contatos - Formulário Principal

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
            List<EstadoInfo> listaEstado = new List<EstadoInfo>();

            //using (EstadoBLL estadoBLL = new EstadoBLL())
            //{
            listaEstado = estadoBLL.Listar();
            //}

            ddlEstado.Items.Clear();
            
            ddlEstado.Items.Add("Selecione o estado...");
            foreach (EstadoInfo obj in listaEstado){
                ddlEstado.Items.Add(obj.DsEstado.Value + " - " + obj.DsUf.Value);            
            }
            ddlEstado.SelectedIndex = 0;
            
            carregarDados(String.Empty);
        }

        private void cadastrarContato(object sender, EventArgs e)
        {
            prepararValidacao(false);

            if (idContato != 0)
            {
                alterarContato();
            }
            else if (validarCampos() && camposVazios.Count == 0)
            {

                CidadeContatoEstadoView novoCadastro = new CidadeContatoEstadoView();                

                novoCadastro = prepararCadastro(false);

                //using (ContatoBLL contatoBLL = new ContatoBLL())
                //{

                //    using (CidadeBLL cidadeBLL = new CidadeBLL())
                //    {
                novoCadastro.Contato.CdCidade.Value = cidadeBLL.Get(cidadeBLL.Inserir(novoCadastro.Cidade)).CdCidade.Value;
                //    }

                contatoBLL.Inserir(novoCadastro.Contato);
                //}

                

                carregarDados(String.Empty);
                limparCadastro();
            }
        }

        private void alterarContato()
        {
            prepararValidacao(false);            

            if (validarCampos() && camposVazios.Count == 0)
            {

                DialogResult respostaUsuario = MessageBox.Show("Tem certeza que deseja alterar o contato?", "Confirma Alteração", MessageBoxButtons.YesNo);

                if (respostaUsuario == DialogResult.Yes)
                {
                    //using (ContatoBLL contatoBLL = new ContatoBLL())
                    //{
                    contatoBLL.Atualizar(idContato, prepararCadastro(true).Contato);

                    //    using (CidadeBLL cidadeBLL = new CidadeBLL())
                    //    {                            
                    cidadeBLL.Atualizar(idCidade, prepararCadastro(true).Cidade);
                    //    }                        
                    //}

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
                    //using (ContatoBLL contatoBLL = new ContatoBLL())
                    //{
                    contatoBLL.Deletar(idContato);

                    //    using (CidadeBLL cidadeBLL = new CidadeBLL())
                    //    {
                    cidadeBLL.Deletar(idCidade);
                    //    }
                    //}

                    carregarDados(String.Empty);
                    limparCadastro();
                }
            }
            else
            {
                MessageBox.Show("Nenhum contato foi selecionado.");
            }

        }

        private DataTable carregarDados(string busca)
        {
            List<ContatoInfo> listaContato = new List<ContatoInfo>();            

            //using (ContatoBLL contatoBLL = new ContatoBLL())
            //{
            listaContato = contatoBLL.Listar();
            //}
            
            DataTable tabelaContatos = new DataTable();

            tabelaContatos.Columns.Add(new DataColumn("Nome"));
            tabelaContatos.Columns.Add(new DataColumn("E-mail"));
            tabelaContatos.Columns.Add(new DataColumn("Data de Nascimento"));
            tabelaContatos.Columns.Add(new DataColumn("CPF"));
            tabelaContatos.Columns.Add(new DataColumn("Cidade"));
            tabelaContatos.Columns.Add(new DataColumn("UF"));
            tabelaContatos.Columns.Add(new DataColumn("Endereço"));
            tabelaContatos.Columns.Add(new DataColumn("CdCidade"));
            tabelaContatos.Columns.Add(new DataColumn("CdEstado"));
            tabelaContatos.Columns.Add(new DataColumn("CdContato"));

            object[] linhasContato = new object[10];

            foreach (ContatoInfo obj in listaContato)
            {
                CidadeInfo cidadeInfo = new CidadeInfo();
                EstadoInfo estadoInfo = new EstadoInfo();

                //using (CidadeBLL cidadeBLL = new CidadeBLL())
                //{
                cidadeInfo = cidadeBLL.Get(obj.CdCidade.Value);
                //}

                //using (EstadoBLL estadoBLL = new EstadoBLL())
                //{
                estadoInfo = estadoBLL.Get(obj.CdEstado.Value);
                //}                

                linhasContato[0] = obj.DsNome.Value;
                linhasContato[1] = obj.DsEmail.Value;
                linhasContato[2] = obj.DtNascimento.Value.Date.Day + "/" + obj.DtNascimento.Value.Date.Month + "/" + obj.DtNascimento.Value.Date.Year;
                linhasContato[3] = obj.DsCpf.Value;
                if (cidadeInfo != null) linhasContato[4] = cidadeInfo.DsCidade.Value;
                if (estadoInfo != null) linhasContato[5] = estadoInfo.DsUf.Value;
                linhasContato[6] = obj.DsEndereco.Value;
                linhasContato[7] = obj.CdCidade.Value;
                linhasContato[8] = obj.CdEstado.Value;                
                linhasContato[9] = obj.CdContato.Value;

                DataRow linha;

                linha = tabelaContatos.Rows.Add(linhasContato);
            }

            if (!String.IsNullOrEmpty(busca))
            {
                DataTable tabelaBusca = tabelaContatos.Clone();
                var linhas = tabelaContatos.AsEnumerable().Where(row => row.Field<String>("Nome").Contains(busca))
                                                .OrderBy(row => row.Field<String>("Nome"));

                //var linhas2 = listaContato.AsEnumerable().Where(row => row.DsNome.Value.Contains(busca))
                //                                   .OrderBy(row => row.DsNome.Value);

                foreach (var linha in linhas)
                    tabelaBusca.ImportRow(linha);

                tabelaContatos = tabelaBusca;
            }

            tabelaContatos.AcceptChanges();
                        
            grvContato.DataSource = tabelaContatos;


            grvContato.Columns[0].Width = 100; // Coluna Nome
            grvContato.Columns[1].Width = 180; // Coluna E-mail
            grvContato.Columns[2].Width = 75; // Coluna Data Nascimento
            grvContato.Columns[3].Width = 75; // Coluna CPF
            grvContato.Columns[4].Width = 100; // Coluna Cidade
            grvContato.Columns[5].Width = 30; // Coluna UF
            grvContato.Columns[6].Width = 165; // Coluna Endereço            

            grvContato.Columns[7].IsVisible = false;
            grvContato.Columns[8].IsVisible = false;
            grvContato.Columns[9].IsVisible = false;

            grvContato.ReadOnly = true;

            return tabelaContatos;
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
            contato.Contato.CdEstado.Value = ((ddlEstado.SelectedIndex));
            contato.Contato.DsEndereco.Value = txtEndereco.Text;
            contato.Cidade.DsCidade.Value = txtCidade.Text;
            contato.Cidade.CdEstado.Value = ((ddlEstado.SelectedIndex));

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
            Controls.OfType<RadTextBox>().ToList().ForEach(t => t.Clear());
            Controls.OfType<RadMaskedEditBox>().ToList().ForEach(t => t.ResetText());

            List<EstadoInfo> listaEstado = new List<EstadoInfo>();

            //using (EstadoBLL estadoBLL = new EstadoBLL())
            //{
            listaEstado = estadoBLL.Listar();
            //}

            ddlEstado.Items.Clear();

            ddlEstado.Items.Add("Selecione o estado...");
            foreach (EstadoInfo obj in listaEstado)
            {
                ddlEstado.Items.Add(obj.DsEstado.Value + " - " + obj.DsUf.Value);
            }
            ddlEstado.SelectedIndex = 0;

            idContato = 0;
            idCidade = 0;
            idEstado = 0;
            btnExcluir.Visible = false;

            prepararValidacao(true);
        }

        private void prepararValidacao(bool limpar)
        {
            eprValidacao.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            txtNome.Tag = txtEmail.Tag = txtDtNasc.Tag = txtCPF.Tag = "Este campo é obrigatório.";

            validarTextBox(txtNome, EventArgs.Empty, limpar);
            validarTextBox(txtEmail, EventArgs.Empty, limpar);
            validarMaskedTextBox(txtDtNasc, EventArgs.Empty, limpar);
            validarMaskedTextBox(txtCPF, EventArgs.Empty, limpar);
        }        

        private void validarTextBox(object sender, EventArgs e, bool limpar)
        {
            var textBox = sender as RadTextBox;
            if (textBox.Text == String.Empty && !limpar)
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

        private void validarMaskedTextBox(object sender, EventArgs e, bool limpar)
        {
            var maskedTextBox = sender as RadMaskedEditBox;
            if (new String(maskedTextBox.Text.Where(Char.IsDigit).ToArray()) == String.Empty && !limpar)
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

            if (txtNome.Text != String.Empty && !Validacao.ValidaNome(txtNome.Text))
            {
                mensagemValidacao += "Nome completo inválido.\n";
            }

            if (txtEmail.Text != String.Empty && !Validacao.ValidaEmail(txtEmail.Text))
            {
                mensagemValidacao += "E-mail inválido.\n";                
            }

            if (new String(txtDtNasc.Text.Where(Char.IsDigit).ToArray()) != String.Empty && !Validacao.ValidaData(txtDtNasc.Text))
            {
                mensagemValidacao += "Data de Nascimento inválida.\n";
            }

            if (new String(txtCPF.Text.Where(Char.IsDigit).ToArray()) != String.Empty && !Validacao.ValidaCPF(txtCPF.Text, idContato))
            {
                mensagemValidacao += "Número do CPF inválido ou já cadastrado.\n";                
            }

            if (mensagemValidacao != String.Empty)
            {
                MessageBox.Show(mensagemValidacao);
                mensagemValidacao = String.Empty;
                return false;
            }

            return true;
        }

        private void selecionarCelulaAntigo(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void visualizarRelatorio(object sender, EventArgs e)
        {            
            List<ContatoInfo> listaContato = new List<ContatoInfo>();

            using (ContatoBLL contatoBLL = new ContatoBLL())
            {
                listaContato = contatoBLL.Listar();
            }            

            frmRelatorio form = new frmRelatorio();

            Telerik.Reporting.Report rpt = new Telerik.Reporting.Report();

            if (!ckbAgruparPorUF.Checked)
            {
                rpt = new GerenciamentoContatos.rptContatos();

                rpt.DataSource = carregarDados(txtBusca.Text);

                rpt.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;

                form.Width = 870;

                form.Height = 1000;

                form.StartPosition = FormStartPosition.CenterScreen;

                form.Show();

                form.CarregarRelatorio(rpt);
            }
            else
            {
                rpt = new GerenciamentoContatos.rptContatosAgrupado();

                rpt.DataSource = carregarDados(txtBusca.Text);

                rpt.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;

                form.Width = 700;

                form.Height = 450;

                form.StartPosition = FormStartPosition.CenterScreen;

                form.Show();

                form.CarregarRelatorio(rpt);
            }
        }

        private void selecionarCelular(object sender, GridViewCellEventArgs e)
        {
            try
            {
                idContato = Convert.ToInt32(grvContato.Rows[e.RowIndex].Cells[9].Value.ToString());
                idEstado = Convert.ToInt32(grvContato.Rows[e.RowIndex].Cells[8].Value.ToString());
                idCidade = Convert.ToInt32(grvContato.Rows[e.RowIndex].Cells[7].Value.ToString());

                DateTime data = Convert.ToDateTime(grvContato.Rows[e.RowIndex].Cells[2].Value.ToString());

                txtNome.Text = grvContato.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtEmail.Text = grvContato.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDtNasc.Text = data.Date.ToShortDateString();
                txtCPF.Text = grvContato.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtCidade.Text = grvContato.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtEndereco.Text = grvContato.Rows[e.RowIndex].Cells[6].Value.ToString();

                ddlEstado.SelectedIndex = System.Convert.ToInt32(grvContato.Rows[e.RowIndex].Cells[8].Value);

                btnExcluir.Visible = true;

                prepararValidacao(true);
            }
            catch
            {
                MessageBox.Show("Selecione um contato!", "Aviso");
            }
        }
    }
    #endregion
}