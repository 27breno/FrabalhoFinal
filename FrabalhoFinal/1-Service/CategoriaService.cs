using FrabalhoFinal._2_Repository;
using FrabalhoFinal._3_Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._1_Service
{
    public class CategoriaService
    {
        CategoriaRepository repositorio { get; set; }
        public CategoriaService(string connectionString)
        {
            repositorio = new CategoriaRepository(connectionString);
        }
        public void Adicionar(Categoria a)
        {
            repositorio.Adicionar(a);
        }

        public List<Categoria> Listar()
        {
            return repositorio.listar();
        }
        public void editar(Categoria a)
        {
            repositorio.editar(a);
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }
    }
}
