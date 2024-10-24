using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._3_Entidade.DTO.Pessoas
{
    public class CreatePessoa
    {

        public string Nome { get; set; }

        public int Idade { get; set; }

        public int CPF { get; set; }

        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
