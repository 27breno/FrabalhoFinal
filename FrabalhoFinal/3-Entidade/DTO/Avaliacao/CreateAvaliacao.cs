using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._3_Entidade.DTO.Avaliacao
{
    public class CreateAvaliacao
    {
        
        public int ConteudoId { get; set; }
        public int PessoaId { get; set; }
        public int Nota { get; set; }/*de 0 a 5 */
        public string Comentario { get; set; }
    }
}
