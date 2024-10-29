using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._3_Entidade.DTO.MinhaLista
{
    public class DTOminhalista
    {
        public int Id { get; set; }
        public  Categoria CategoriaId { get; set; }

        public Conteudo ConteudoId { get; set; }
    }
}
