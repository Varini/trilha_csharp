using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ContatoModelo
    {
        public string CdContato { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DtNasc { get; set; }
        public string CPF { get; set; }
        public string CdCidade { get; set; }
        public string Cidade { get; set; }
        public string CdEstado { get; set; }
        public string UF { get; set; }
        public string Endereco { get; set; }        

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
