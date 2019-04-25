using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class EstadoModelo
    {
        public string ID { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }

        public override string ToString()
        {
            return this.Descricao + " - " + this.Sigla;
        }
    }
}