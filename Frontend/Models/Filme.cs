using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._3_Entidade
{
    public class Filme
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int AnodeCriacao { get; set;}

        public override string ToString()
        {
            return $"Id: {Id} Assinatura: Nome do filme: {Nome}, Ano do lançamento: {AnodeCriacao} ";
        }
    }
}
