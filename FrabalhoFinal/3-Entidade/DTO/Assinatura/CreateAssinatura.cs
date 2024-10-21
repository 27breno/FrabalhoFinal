using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._3_Entidade.DTO.Assinatura
{
    public class CreateAssinatura


    {
        
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; } // Pode ser nulo se a assinatura estiver ativa
        public string Status { get; set; }
        public decimal Valor { get; set; }
        public int Pessoaid { get; set; }
    }
}
