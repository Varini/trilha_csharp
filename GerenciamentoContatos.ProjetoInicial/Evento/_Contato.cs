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
    public class Contato
    {
        public static void Gravar(ContatoModelo contato)
        {
            new Banco.Contato().Gravar(contato.Nome, contato.Email, contato.DtNasc, contato.CPF, contato.CdCidade, contato.Cidade, contato.CdEstado, contato.Endereco);
        }

        public static void Atualizar(ContatoModelo contato)
        {
            new Banco.Contato().Atualizar(contato.CdContato, contato.Nome, contato.Email, contato.DtNasc, contato.CPF, contato.CdCidade, contato.Cidade, contato.CdEstado, contato.Endereco);
        }

        public static void Deletar(string cdContato)
        {
            new Banco.Contato().Deletar(cdContato);
        }

        public static List<ContatoModelo> Buscar(string busca)
        {
            var list = new List<ContatoModelo>();
            var tabela = new Banco.Contato().Buscar(busca);
            if (tabela.Rows.Count > 0)
            {
                foreach (DataRow row in tabela.Rows)
                {
                    list.Add(new ContatoModelo()
                    {
                        Endereco = row["ds_endereco"].ToString(),
                        CdEstado = row["cd_estado"].ToString(),
                        Cidade = row["ds_cidade"].ToString(),
                        UF = row["ds_uf"].ToString(),
                        CPF = row["ds_cpf"].ToString(),
                        DtNasc = row["dt_nascimento_formatada"].ToString(),
                        Email = row["ds_email"].ToString(),
                        Nome = row["ds_nome"].ToString(),
                        CdContato = row["cd_contato"].ToString()
                    });

                    Console.WriteLine(row["dt_nascimento"]);
                }
            }
            return list;
        }
    }
}
