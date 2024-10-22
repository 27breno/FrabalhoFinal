using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._3_Entidade
{
    public class Conteudo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int AnoLancamento { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; } // Duração do conteúdo
        public int CategoriaId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Assinatura: Titulod do filme: {Titulo}, Descrição do filme: {Descricao}, Ano do lançamento: {AnoLancamento} " +
                $" Genero do filme: {Genero}, Duração {Duracao}";
        }
    }
}
