using System;
using System.Collections.Generic;
using Smart.Database;
using Smart.Model;
using GerenciamentoContatos.Model;
using GerenciamentoContatos.DAL;

namespace GerenciamentoContatos.BLL
{
	public class EstadoBLL : Smart.Model.BusinessObject
	{
		public EstadoBLL() { }

		public EstadoBLL(DbConn pDbHnd) : base (pDbHnd) { }

		public EstadoInfo Get(Int32 pCdEstado)
		{
			EstadoDAL dal = new EstadoDAL(this.DbHnd);
			return dal.Get(pCdEstado);
		}

		public Int32 Inserir(EstadoInfo pInfo)
		{
			EstadoDAL dal = new EstadoDAL(this.DbHnd);
			return dal.Inserir(pInfo);
		}

		public void Atualizar(Int32 pCdEstado, EstadoInfo pInfo)
		{
			EstadoDAL dal = new EstadoDAL(this.DbHnd);
			dal.Atualizar(pCdEstado, pInfo);
		}
		public void Deletar(Int32 pCdEstado)
		{
			EstadoDAL dal = new EstadoDAL(this.DbHnd);
			dal.Deletar(pCdEstado);
		}
		public List<EstadoInfo> Listar()
		{
			EstadoDAL dal = new EstadoDAL(this.DbHnd);
			dal.Filters = this.Filters;
			return dal.Listar();
		}
		public List<EstadoInfo> ListarPaginado()
		{
			EstadoDAL dal = new EstadoDAL(this.DbHnd);
			dal.Filters = this.Filters;
			return dal.ListarPaginado();
		}
	}
}
