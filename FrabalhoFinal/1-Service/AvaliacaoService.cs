using FrabalhoFinal._1_Service.Interfaces;
using FrabalhoFinal._2_Repository;
using FrabalhoFinal._2_Repository.Interface;
using FrabalhoFinal._3_Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._1_Service
{
    public class AvaliacaoService : IAvaliacaoService
    {
        IAvaliacaoRepository repositorio { get; set; }
        public AvaliacaoService(IAvaliacaoRepository avaliacaorepository)
        {
            repositorio = avaliacaorepository;
        }
        public void Adicionar(Avaliacao a)
        {
            repositorio.Adicionar(a);
        }

        public List<Avaliacao> Listar()
        {
            return repositorio.listar();
        }
        public void editar(Avaliacao a)
        {
            repositorio.editar(a);
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }
    }
}
