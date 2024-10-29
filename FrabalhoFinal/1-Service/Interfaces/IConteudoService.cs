using FrabalhoFinal._3_Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._1_Service.Interfaces
{
    public interface IConteudoService
    {
        void Adicionar(Conteudo a);



         List<Conteudo> Listar();
            

         void editar(Conteudo a);


         void Remover(int id);

    }
}
