using System;
using Smart.Model;

namespace GerenciamentoContatos.Model
{
	public class ContatoInfo : Smart.Model.DbTable
	{
		public ContatoInfo()
		{
		}

		/// <summary>
		/// All fields constructor (Except Auto Increment)
		/// </summary>
		/// <param name="pCdCidade">Default value for property 'CdCidade'</param>
		/// <param name="pCdEstado">Default value for property 'CdEstado'</param>
		/// <param name="pDtNascimento">Default value for property 'DtNascimento'</param>
		/// <param name="pDsCpf">Default value for property 'DsCpf'</param>
		/// <param name="pDsNome">Default value for property 'DsNome'</param>
		/// <param name="pDsEmail">Default value for property 'DsEmail'</param>
		/// <param name="pDsEndereco">Default value for property 'DsEndereco'</param>
		public ContatoInfo(Int32 pCdCidade, Int32 pCdEstado, DateTime pDtNascimento, String pDsCpf, String pDsNome, String pDsEmail, String pDsEndereco)
		{
			_CdCidade.Value = pCdCidade;
			_CdEstado.Value = pCdEstado;
			_DtNascimento.Value = pDtNascimento;
			_DsCpf.Value = pDsCpf;
			_DsNome.Value = pDsNome;
			_DsEmail.Value = pDsEmail;
			_DsEndereco.Value = pDsEndereco;
		}

		/// <summary>
		/// Not null fields constructor (Except Auto Increment)
		/// </summary>
		/// <param name="pCdEstado">Default value for property 'CdEstado'</param>
		public ContatoInfo(Int32 pCdEstado)
		{
			_CdEstado.Value = pCdEstado;
		}

		static public Int32DbField GetCdContato()
		{
			return _GetCdContato();
		}
		static public Int32DbField GetCdContato(Int32 pCdContato)
		{
			Int32DbField dbfield = _GetCdContato();
			dbfield.Value = pCdContato;
			return dbfield;
		}
		static Int32DbField _GetCdContato()
		{
			Int32DbField dbfield = new Int32DbField();
			dbfield.AllowsNull = false;
			dbfield.DataTypeName = "int";
			dbfield.DefaultValue = "";
			dbfield.IsAutoId = true;
			dbfield.IsPrimaryKey = true;
			dbfield.Name = "cd_contato";
			dbfield.Scale = 0;
			dbfield.Size = 4;
			dbfield.TableName = "CONTATO";
			return dbfield;
		}
		static public Int32DbField GetCdCidade()
		{
			return _GetCdCidade();
		}
		static public Int32DbField GetCdCidade(System.DBNull val)
		{
			Int32DbField dbfield = _GetCdCidade();
			dbfield.IsNullValue = true;
			return dbfield;
		}
		static public Int32DbField GetCdCidade(Int32 pCdCidade)
		{
			Int32DbField dbfield = _GetCdCidade();
			dbfield.Value = pCdCidade;
			return dbfield;
		}
		static Int32DbField _GetCdCidade()
		{
			Int32DbField dbfield = new Int32DbField();
			dbfield.AllowsNull = true;
			dbfield.DataTypeName = "int";
			dbfield.DefaultValue = "";
			dbfield.IsAutoId = false;
			dbfield.IsPrimaryKey = false;
			dbfield.Name = "cd_cidade";
			dbfield.Scale = 0;
			dbfield.Size = 4;
			dbfield.TableName = "CONTATO";
			return dbfield;
		}
		static public Int32DbField GetCdEstado()
		{
			return _GetCdEstado();
		}
		static public Int32DbField GetCdEstado(Int32 pCdEstado)
		{
			Int32DbField dbfield = _GetCdEstado();
			dbfield.Value = pCdEstado;
			return dbfield;
		}
		static Int32DbField _GetCdEstado()
		{
			Int32DbField dbfield = new Int32DbField();
			dbfield.AllowsNull = false;
			dbfield.DataTypeName = "int";
			dbfield.DefaultValue = "";
			dbfield.IsAutoId = false;
			dbfield.IsPrimaryKey = false;
			dbfield.Name = "cd_estado";
			dbfield.Scale = 0;
			dbfield.Size = 4;
			dbfield.TableName = "CONTATO";
			return dbfield;
		}
		static public DateTimeDbField GetDtNascimento()
		{
			return _GetDtNascimento();
		}
		static public DateTimeDbField GetDtNascimento(System.DBNull val)
		{
			DateTimeDbField dbfield = _GetDtNascimento();
			dbfield.IsNullValue = true;
			return dbfield;
		}
		static public DateTimeDbField GetDtNascimento(DateTime pDtNascimento)
		{
			DateTimeDbField dbfield = _GetDtNascimento();
			dbfield.Value = pDtNascimento;
			return dbfield;
		}
		static DateTimeDbField _GetDtNascimento()
		{
			DateTimeDbField dbfield = new DateTimeDbField();
			dbfield.AllowsNull = true;
			dbfield.DataTypeName = "datetime";
			dbfield.DefaultValue = "";
			dbfield.IsAutoId = false;
			dbfield.IsPrimaryKey = false;
			dbfield.Name = "dt_nascimento";
			dbfield.Scale = 3;
			dbfield.Size = 8;
			dbfield.TableName = "CONTATO";
			return dbfield;
		}
		static public StringDbField GetDsCpf()
		{
			return _GetDsCpf();
		}
		static public StringDbField GetDsCpf(System.DBNull val)
		{
			StringDbField dbfield = _GetDsCpf();
			dbfield.IsNullValue = true;
			return dbfield;
		}
		static public StringDbField GetDsCpf(String pDsCpf)
		{
			StringDbField dbfield = _GetDsCpf();
			dbfield.Value = pDsCpf;
			return dbfield;
		}
		static StringDbField _GetDsCpf()
		{
			StringDbField dbfield = new StringDbField();
			dbfield.AllowsNull = true;
			dbfield.DataTypeName = "varchar";
			dbfield.DefaultValue = "";
			dbfield.IsAutoId = false;
			dbfield.IsPrimaryKey = false;
			dbfield.Name = "ds_cpf";
			dbfield.Scale = 0;
			dbfield.Size = 11;
			dbfield.TableName = "CONTATO";
			return dbfield;
		}
		static public StringDbField GetDsNome()
		{
			return _GetDsNome();
		}
		static public StringDbField GetDsNome(System.DBNull val)
		{
			StringDbField dbfield = _GetDsNome();
			dbfield.IsNullValue = true;
			return dbfield;
		}
		static public StringDbField GetDsNome(String pDsNome)
		{
			StringDbField dbfield = _GetDsNome();
			dbfield.Value = pDsNome;
			return dbfield;
		}
		static StringDbField _GetDsNome()
		{
			StringDbField dbfield = new StringDbField();
			dbfield.AllowsNull = true;
			dbfield.DataTypeName = "varchar";
			dbfield.DefaultValue = "";
			dbfield.IsAutoId = false;
			dbfield.IsPrimaryKey = false;
			dbfield.Name = "ds_nome";
			dbfield.Scale = 0;
			dbfield.Size = 255;
			dbfield.TableName = "CONTATO";
			return dbfield;
		}
		static public StringDbField GetDsEmail()
		{
			return _GetDsEmail();
		}
		static public StringDbField GetDsEmail(System.DBNull val)
		{
			StringDbField dbfield = _GetDsEmail();
			dbfield.IsNullValue = true;
			return dbfield;
		}
		static public StringDbField GetDsEmail(String pDsEmail)
		{
			StringDbField dbfield = _GetDsEmail();
			dbfield.Value = pDsEmail;
			return dbfield;
		}
		static StringDbField _GetDsEmail()
		{
			StringDbField dbfield = new StringDbField();
			dbfield.AllowsNull = true;
			dbfield.DataTypeName = "varchar";
			dbfield.DefaultValue = "";
			dbfield.IsAutoId = false;
			dbfield.IsPrimaryKey = false;
			dbfield.Name = "ds_email";
			dbfield.Scale = 0;
			dbfield.Size = 100;
			dbfield.TableName = "CONTATO";
			return dbfield;
		}
		static public StringDbField GetDsEndereco()
		{
			return _GetDsEndereco();
		}
		static public StringDbField GetDsEndereco(System.DBNull val)
		{
			StringDbField dbfield = _GetDsEndereco();
			dbfield.IsNullValue = true;
			return dbfield;
		}
		static public StringDbField GetDsEndereco(String pDsEndereco)
		{
			StringDbField dbfield = _GetDsEndereco();
			dbfield.Value = pDsEndereco;
			return dbfield;
		}
		static StringDbField _GetDsEndereco()
		{
			StringDbField dbfield = new StringDbField();
			dbfield.AllowsNull = true;
			dbfield.DataTypeName = "varchar";
			dbfield.DefaultValue = "";
			dbfield.IsAutoId = false;
			dbfield.IsPrimaryKey = false;
			dbfield.Name = "ds_endereco";
			dbfield.Scale = 0;
			dbfield.Size = 170;
			dbfield.TableName = "CONTATO";
			return dbfield;
		}
		private Int32DbField _CdContato = GetCdContato();
		public Int32DbField CdContato
		{
			get { return _CdContato; }
			set { _CdContato = value; }
		}

		private Int32DbField _CdCidade = GetCdCidade();
		public Int32DbField CdCidade
		{
			get { return _CdCidade; }
			set { _CdCidade = value; }
		}

		private Int32DbField _CdEstado = GetCdEstado();
		public Int32DbField CdEstado
		{
			get { return _CdEstado; }
			set { _CdEstado = value; }
		}

		private DateTimeDbField _DtNascimento = GetDtNascimento();
		public DateTimeDbField DtNascimento
		{
			get { return _DtNascimento; }
			set { _DtNascimento = value; }
		}

		private StringDbField _DsCpf = GetDsCpf();
		public StringDbField DsCpf
		{
			get { return _DsCpf; }
			set { _DsCpf = value; }
		}

		private StringDbField _DsNome = GetDsNome();
		public StringDbField DsNome
		{
			get { return _DsNome; }
			set { _DsNome = value; }
		}

		private StringDbField _DsEmail = GetDsEmail();
		public StringDbField DsEmail
		{
			get { return _DsEmail; }
			set { _DsEmail = value; }
		}

		private StringDbField _DsEndereco = GetDsEndereco();
		public StringDbField DsEndereco
		{
			get { return _DsEndereco; }
			set { _DsEndereco = value; }
		}

	}
}
