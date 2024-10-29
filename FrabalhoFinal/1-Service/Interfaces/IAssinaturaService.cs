using FrabalhoFinal._3_Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._1_Service.Interfaces
{
    public interface IAssinaturaService
    {
        void Adicionar(Assinatura a);


        List<Assinatura> Listar();

        void editar(Assinatura a);

        void Remover(int id);
        
    }
}
