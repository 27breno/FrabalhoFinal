using FrabalhoFinal._2_Repository;
using FrabalhoFinal._3_Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._1_Service
{
    public class FilmeService
    {
        FilmeRepository repositorio { get; set; }
        public FilmeService(string connectionString)
        {
            repositorio = new FilmeRepository(connectionString);
        }
        public void Adicionar(Filme a)
        {
            repositorio.Adicionar(a);
        }

        public List<Filme> Listar()
        {
            return repositorio.listar();
        }
        public void editar(Filme a)
        {
            repositorio.editar(a);
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }
    }
}
