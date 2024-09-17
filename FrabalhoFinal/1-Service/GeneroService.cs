using FrabalhoFinal._2_Repository;
using FrabalhoFinal._3_Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._1_Service
{
    public class GeneroService
    {
        GeneroRepository repositorio { get; set; }
        public GeneroService(string connectionString)
        {
            repositorio = new GeneroRepository(connectionString);
        }
        public void Adicionar(Genero a)
        {
            repositorio.Adicionar(a);
        }

        public List<Genero> Listar()
        {
            return repositorio.listar();
        }
        public void editar(Genero a)
        {
            repositorio.editar(a);
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }
    }
}

