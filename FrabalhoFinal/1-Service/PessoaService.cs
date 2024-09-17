
using FrabalhoFinal._2_Repository;
using FrabalhoFinal._3_Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._1_Service
{
    public class PessoaService
    {

        PessoaRepository repositorio { get; set; }
        public PessoaService(string connectionString)
        {
            repositorio = new PessoaRepository(connectionString);
        }
        public void Adicionar(Pessoa a)
        {
            repositorio.Adicionar(a);
        }

        public List<Pessoa> Listar()
        {
            return repositorio.listar();
        }
        public void editar(Pessoa a)
        {
            repositorio.editar(a);
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }

    }

}