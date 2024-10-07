using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._3_Entidade
{
    public  class Plano
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Duracao { get; set; } // ex: "mensal", "anual"
        public string Recursos { get; set; } // ex: "2 telas, HD"
    }
}
