using FrabalhoFinal._2_Repository;
using FrabalhoFinal._3_Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._1_Service
{
    public class AssinaturaService
    {
        AssinaturaRepository repositorio { get; set; }
        public AssinaturaService(string connectionString)
        {
            repositorio = new AssinaturaRepository(connectionString);
        }
        public void Adicionar(Assinatura  a)
        {
            repositorio.Adicionar(a);
        }

        public List<Assinatura> Listar()
        {
            return repositorio.listar();
        }
        public void editar(Assinatura a)
        {
            repositorio.editar(a);
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }
    }
}
