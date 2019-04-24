namespace GerenciamentoContatos
{
    partial class frmContato
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblNome = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNome = new Telerik.WinControls.UI.RadTextBox();
            this.txtCidade = new Telerik.WinControls.UI.RadTextBox();
            this.ddlEstado = new System.Windows.Forms.ComboBox();
            this.txtEndereco = new Telerik.WinControls.UI.RadTextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.txtCPF = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.eprValidacao = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtEmail = new Telerik.WinControls.UI.RadTextBox();
            this.txtDtNasc = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.grvContato = new System.Windows.Forms.DataGridView();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBusca = new Telerik.WinControls.UI.RadTextBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtNome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndereco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCPF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eprValidacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDtNasc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvContato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBusca)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(28, 33);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(42, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome*:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email*:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data de Nascimento*:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "CPF*:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cidade:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Estado:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Endereço:";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNome.Location = new System.Drawing.Point(142, 29);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(248, 18);
            this.txtNome.TabIndex = 1;
            this.txtNome.TabStop = false;
            // 
            // txtCidade
            // 
            this.txtCidade.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCidade.Location = new System.Drawing.Point(142, 145);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(248, 20);
            this.txtCidade.TabIndex = 5;
            this.txtCidade.TabStop = false;
            // 
            // ddlEstado
            // 
            this.ddlEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlEstado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlEstado.FormattingEnabled = true;
            this.ddlEstado.Location = new System.Drawing.Point(142, 174);
            this.ddlEstado.Name = "ddlEstado";
            this.ddlEstado.Size = new System.Drawing.Size(248, 21);
            this.ddlEstado.TabIndex = 6;
            // 
            // txtEndereco
            // 
            this.txtEndereco.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndereco.Location = new System.Drawing.Point(142, 204);
            this.txtEndereco.Multiline = true;
            this.txtEndereco.Name = "txtEndereco";
            // 
            // 
            // 
            this.txtEndereco.RootElement.StretchVertically = true;
            this.txtEndereco.Size = new System.Drawing.Size(248, 69);
            this.txtEndereco.TabIndex = 7;
            this.txtEndereco.TabStop = false;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(12, 299);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(75, 23);
            this.btnCadastrar.TabIndex = 8;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.cadastrarContato);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(315, 299);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 10;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.acionarLimpar);
            // 
            // txtCPF
            // 
            this.txtCPF.AutoSize = true;
            this.txtCPF.Location = new System.Drawing.Point(142, 116);
            this.txtCPF.Mask = "000.000.000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(100, 20);
            this.txtCPF.TabIndex = 4;
            this.txtCPF.TabStop = false;
            // 
            // eprValidacao
            // 
            this.eprValidacao.ContainerControl = this;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEmail.Location = new System.Drawing.Point(142, 58);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(248, 18);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.TabStop = false;
            // 
            // txtDtNasc
            // 
            this.txtDtNasc.AutoSize = true;
            this.txtDtNasc.Location = new System.Drawing.Point(142, 87);
            this.txtDtNasc.Mask = "00/00/0000";
            this.txtDtNasc.Name = "txtDtNasc";
            this.txtDtNasc.Size = new System.Drawing.Size(100, 20);
            this.txtDtNasc.TabIndex = 3;
            this.txtDtNasc.TabStop = false;
            // 
            // grvContato
            // 
            this.grvContato.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grvContato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvContato.Location = new System.Drawing.Point(12, 328);
            this.grvContato.Name = "grvContato";
            this.grvContato.Size = new System.Drawing.Size(745, 185);
            this.grvContato.TabIndex = 13;
            this.grvContato.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.selecionarCelula);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(93, 299);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 9;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Visible = false;
            this.btnExcluir.Click += new System.EventHandler(this.excluirContato);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(682, 299);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.buscarCadastro);
            // 
            // txtBusca
            // 
            this.txtBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusca.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBusca.Location = new System.Drawing.Point(535, 302);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(141, 18);
            this.txtBusca.TabIndex = 11;
            this.txtBusca.TabStop = false;
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(500, 305);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(32, 13);
            this.lblFiltro.TabIndex = 15;
            this.lblFiltro.Text = "Filtro:";
            // 
            // frmContato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 525);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.grvContato);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.txtDtNasc);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.ddlEstado);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmContato";
            this.Text = "Gerenciamento de Contatos";
            this.Load += new System.EventHandler(this.carregarFrmContato);
            ((System.ComponentModel.ISupportInitialize)(this.txtNome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndereco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCPF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eprValidacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDtNasc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvContato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBusca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Telerik.WinControls.UI.RadTextBox txtNome;
        private Telerik.WinControls.UI.RadTextBox txtCidade;
        private System.Windows.Forms.ComboBox ddlEstado;
        private Telerik.WinControls.UI.RadTextBox txtEndereco;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnLimpar;
        private Telerik.WinControls.UI.RadMaskedEditBox  txtCPF;
        private System.Windows.Forms.ErrorProvider eprValidacao;
        private Telerik.WinControls.UI.RadTextBox txtEmail;
        private Telerik.WinControls.UI.RadMaskedEditBox  txtDtNasc;
        private System.Windows.Forms.DataGridView grvContato;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Label lblFiltro;
        private Telerik.WinControls.UI.RadTextBox txtBusca;
    }
}

