using FrabalhoFinal._3_Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._1_Service.Interfaces
{
    public interface IAvaliacaoService
    {
        void Adicionar(Avaliacao a);
           

         List<Avaliacao> Listar();


         void editar(Avaliacao a);


         void Remover(int id);
       
    }
}
