using FrabalhoFinal._3_Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._2_Repository.Interface
{
    public interface IAvaliacaoRepository
    {
        void Adicionar(Avaliacao u);
        List<Avaliacao> listar();
        Avaliacao Buscarporid(int id);
        void Remover(int id);
        void editar(Avaliacao u);


    }
}
