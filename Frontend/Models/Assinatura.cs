using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._3_Entidade
{
    public class Assinatura
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; } // Pode ser nulo se a assinatura estiver ativa
        public string Status { get; set; } /*premium, basico*/
        public decimal Valor { get; set; }
        public int Pessoaid { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Assinatura: Data do inicio: {DataInicio}, Data do final: {DataFim}, Status da assinatura: {Status} " +
                $" valor da assinatura: {Valor} ";
        }
    }
}
