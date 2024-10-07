using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._3_Entidade
{
    public class Assinatura
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; } // Pode ser nulo se a assinatura estiver ativa
        public string Status { get; set; }
        public decimal Valor { get; set; }
        public string FormaPagamento { get; set; }
        public int Pessoaid { get; set; } 
        public int PlanoId { get; set; }
    }
}
