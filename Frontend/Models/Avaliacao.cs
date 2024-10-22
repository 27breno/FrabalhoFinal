using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int ConteudoId { get; set; }
        public int PessoaId { get; set; }
        public int Nota { get; set; }/*de 0 a 5 */
        public string Comentario { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Avaliação: Conteudo: {ConteudoId}, Pessoa: {PessoaId}, Avaliãção: {Nota} " +
                $" Comentario: {Comentario} ";
        }
    }
}
