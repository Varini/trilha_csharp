using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Modelo;

namespace Evento
{
    public class Estado
    {
        public static void Gravar(ContatoModelo contato)
        {
            
        }

        public static void Atualizar(ContatoModelo contato)
        {
            
        }

        public static void Deletar(string cdContato)
        {
            
        }

        public static List<EstadoModelo> Buscar(string busca)
        {
            var list = new List<EstadoModelo>();
            var tabela = new Banco._Estado().Buscar(busca);
            if (tabela.Rows.Count > 0)
            {
                foreach (DataRow row in tabela.Rows)
                {
                    list.Add(new EstadoModelo()
                    {
                        Sigla = row["ds_uf"].ToString(),
                        Descricao = row["ds_estado"].ToString(),                        
                    });
                }
            }
            return list;
        }
    }
}
