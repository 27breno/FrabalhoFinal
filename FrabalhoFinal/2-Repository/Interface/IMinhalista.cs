using FrabalhoFinal._3_Entidade.DTO.MinhaLista;
using FrabalhoFinal._3_Entidade;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._2_Repository.Interface
{
    public interface IMinhalista
    {
        void Adicionar(MinhaLista carrinho);


         void Remover(int id);



         void Editar(MinhaLista carrinho);


         List<MinhaLista> Listar();



        



         List<DTOminhalista> ListarMinhaListaDoUsuario(int usuarioId);


         MinhaLista BuscarPorId(int id);
      
    }
}
