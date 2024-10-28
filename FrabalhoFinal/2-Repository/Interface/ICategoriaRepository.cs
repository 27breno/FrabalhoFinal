using FrabalhoFinal._3_Entidade;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._2_Repository.Interface
{
    public interface ICategoriaRepository
    {
        void Adicionar(Categoria u);


         List<Categoria> listar();
        Categoria Buscarporid(int id);
            

         void Remover(int id);

         void editar(Categoria u);
     
    }
}
