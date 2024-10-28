using FrabalhoFinal._3_Entidade;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._2_Repository.Interface
{
    public interface IPessoaRepository
    {
        void Adicionar(Pessoa u);


         List<Pessoa> listar();


         Pessoa Buscarporid(int id);


         void Remover(int id);


         void editar(Pessoa u);
       
    }
}
