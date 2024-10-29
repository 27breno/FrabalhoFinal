using FrabalhoFinal._3_Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._1_Service.Interfaces
{
    public interface IPessoaService
    {
        void Adicionar(Pessoa a);

         List<Pessoa> Listar();


         void editar(Pessoa a);


         void Remover(int id);
        


    }
}
