using System;
using Smart.Model;

namespace GerenciamentoContatos.Model
{
	public class CidadeInfo : Smart.Model.DbTable
	{
		public CidadeInfo()
		{
		}

		/// <summary>
		/// All fields constructor (Except Auto Increment)
		/// </summary>
		/// <param name="pCdEstado">Default value for property 'CdEstado'</param>
		/// <param name="pDsCidade">Default value for property 'DsCidade'</param>
		public CidadeInfo(Int32 pCdEstado, String pDsCidade)
		{
			_CdEstado.Value = pCdEstado;
			_DsCidade.Value = pDsCidade;
		}

		/// <summary>
		/// Not null fields constructor (Except Auto Increment)
		/// </summary>
		/// <param name="pCdEstado">Default value for property 'CdEstado'</param>
		public CidadeInfo(Int32 pCdEstado)
		{
			_CdEstado.Value = pCdEstado;
		}

		static public Int32DbField GetCdCidade()
		{
			return _GetCdCidade();
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
			dbfield.AllowsNull = false;
			dbfield.DataTypeName = "int";
			dbfield.DefaultValue = "";
			dbfield.IsAutoId = true;
			dbfield.IsPrimaryKey = true;
			dbfield.Name = "cd_cidade";
			dbfield.Scale = 0;
			dbfield.Size = 4;
			dbfield.TableName = "CIDADE";
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
			dbfield.TableName = "CIDADE";
			return dbfield;
		}
		static public StringDbField GetDsCidade()
		{
			return _GetDsCidade();
		}
		static public StringDbField GetDsCidade(System.DBNull val)
		{
			StringDbField dbfield = _GetDsCidade();
			dbfield.IsNullValue = true;
			return dbfield;
		}
		static public StringDbField GetDsCidade(String pDsCidade)
		{
			StringDbField dbfield = _GetDsCidade();
			dbfield.Value = pDsCidade;
			return dbfield;
		}
		static StringDbField _GetDsCidade()
		{
			StringDbField dbfield = new StringDbField();
			dbfield.AllowsNull = true;
			dbfield.DataTypeName = "varchar";
			dbfield.DefaultValue = "";
			dbfield.IsAutoId = false;
			dbfield.IsPrimaryKey = false;
			dbfield.Name = "ds_cidade";
			dbfield.Scale = 0;
			dbfield.Size = 50;
			dbfield.TableName = "CIDADE";
			return dbfield;
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

		private StringDbField _DsCidade = GetDsCidade();
		public StringDbField DsCidade
		{
			get { return _DsCidade; }
			set { _DsCidade = value; }
		}

	}
}
