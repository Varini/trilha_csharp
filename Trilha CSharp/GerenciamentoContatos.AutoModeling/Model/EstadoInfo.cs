using System;
using Smart.Model;

namespace GerenciamentoContatos.Model
{
	public class EstadoInfo : Smart.Model.DbTable
	{
		public EstadoInfo()
		{
		}

		/// <summary>
		/// All fields constructor (Except Auto Increment)
		/// </summary>
		/// <param name="pDsEstado">Default value for property 'DsEstado'</param>
		/// <param name="pDsUf">Default value for property 'DsUf'</param>
		public EstadoInfo(String pDsEstado, String pDsUf)
		{
			_DsEstado.Value = pDsEstado;
			_DsUf.Value = pDsUf;
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
			dbfield.IsAutoId = true;
			dbfield.IsPrimaryKey = true;
			dbfield.Name = "cd_estado";
			dbfield.Scale = 0;
			dbfield.Size = 4;
			dbfield.TableName = "ESTADO";
			return dbfield;
		}
		static public StringDbField GetDsEstado()
		{
			return _GetDsEstado();
		}
		static public StringDbField GetDsEstado(System.DBNull val)
		{
			StringDbField dbfield = _GetDsEstado();
			dbfield.IsNullValue = true;
			return dbfield;
		}
		static public StringDbField GetDsEstado(String pDsEstado)
		{
			StringDbField dbfield = _GetDsEstado();
			dbfield.Value = pDsEstado;
			return dbfield;
		}
		static StringDbField _GetDsEstado()
		{
			StringDbField dbfield = new StringDbField();
			dbfield.AllowsNull = true;
			dbfield.DataTypeName = "varchar";
			dbfield.DefaultValue = "";
			dbfield.IsAutoId = false;
			dbfield.IsPrimaryKey = false;
			dbfield.Name = "ds_estado";
			dbfield.Scale = 0;
			dbfield.Size = 50;
			dbfield.TableName = "ESTADO";
			return dbfield;
		}
		static public StringDbField GetDsUf()
		{
			return _GetDsUf();
		}
		static public StringDbField GetDsUf(System.DBNull val)
		{
			StringDbField dbfield = _GetDsUf();
			dbfield.IsNullValue = true;
			return dbfield;
		}
		static public StringDbField GetDsUf(String pDsUf)
		{
			StringDbField dbfield = _GetDsUf();
			dbfield.Value = pDsUf;
			return dbfield;
		}
		static StringDbField _GetDsUf()
		{
			StringDbField dbfield = new StringDbField();
			dbfield.AllowsNull = true;
			dbfield.DataTypeName = "varchar";
			dbfield.DefaultValue = "";
			dbfield.IsAutoId = false;
			dbfield.IsPrimaryKey = false;
			dbfield.Name = "ds_uf";
			dbfield.Scale = 0;
			dbfield.Size = 2;
			dbfield.TableName = "ESTADO";
			return dbfield;
		}
		private Int32DbField _CdEstado = GetCdEstado();
		public Int32DbField CdEstado
		{
			get { return _CdEstado; }
			set { _CdEstado = value; }
		}

		private StringDbField _DsEstado = GetDsEstado();
		public StringDbField DsEstado
		{
			get { return _DsEstado; }
			set { _DsEstado = value; }
		}

		private StringDbField _DsUf = GetDsUf();
		public StringDbField DsUf
		{
			get { return _DsUf; }
			set { _DsUf = value; }
		}

	}
}
