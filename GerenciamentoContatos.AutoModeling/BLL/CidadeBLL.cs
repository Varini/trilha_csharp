using System;
using System.Collections.Generic;
using Smart.Database;
using Smart.Model;
using GerenciamentoContatos.Model;
using GerenciamentoContatos.DAL;

namespace GerenciamentoContatos.BLL
{
	public class CidadeBLL : Smart.Model.BusinessObject
	{
		public CidadeBLL() { }

		public CidadeBLL(DbConn pDbHnd) : base (pDbHnd) { }

		public CidadeInfo Get(Int32 pCdCidade)
		{
			CidadeDAL dal = new CidadeDAL(this.DbHnd);
			return dal.Get(pCdCidade);
		}

		public Int32 Inserir(CidadeInfo pInfo)
		{
			CidadeDAL dal = new CidadeDAL(this.DbHnd);
			return dal.Inserir(pInfo);
		}

		public void Atualizar(Int32 pCdCidade, CidadeInfo pInfo)
		{
			CidadeDAL dal = new CidadeDAL(this.DbHnd);
			dal.Atualizar(pCdCidade, pInfo);
		}
		public void Deletar(Int32 pCdCidade)
		{
			CidadeDAL dal = new CidadeDAL(this.DbHnd);
			dal.Deletar(pCdCidade);
		}
		public List<CidadeInfo> Listar()
		{
			CidadeDAL dal = new CidadeDAL(this.DbHnd);
			dal.Filters = this.Filters;
			return dal.Listar();
		}
		public List<CidadeInfo> ListarPaginado()
		{
			CidadeDAL dal = new CidadeDAL(this.DbHnd);
			dal.Filters = this.Filters;
			return dal.ListarPaginado();
		}
	}
}
