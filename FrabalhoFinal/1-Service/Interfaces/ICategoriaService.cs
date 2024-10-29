using FrabalhoFinal._3_Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._1_Service.Interfaces
{
    public interface ICategoriaService
    {
        void Adicionar(Categoria a);


         List<Categoria> Listar();


         void editar(Categoria a);


         void Remover(int id);
      
    }
}
