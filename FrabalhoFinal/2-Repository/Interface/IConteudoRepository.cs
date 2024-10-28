using FrabalhoFinal._3_Entidade;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._2_Repository.Interface
{
    public interface IConteudoRepository
    {
        void Adicionar(Conteudo u);

        List<Conteudo> listar();


         Conteudo Buscarporid(int id);


         void Remover(int id);


         void editar(Conteudo u);
      
    }
}
