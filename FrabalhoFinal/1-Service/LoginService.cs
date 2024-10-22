using FrabalhoFinal._2_Repository;
using FrabalhoFinal._3_Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._1_Service
{
    public class LoginService
    {
        LoginRepository repositorio { get; set; }
        public LoginService(string connectionString)
        {
            repositorio = new LoginRepository(connectionString);
        }
        public void Adicionar(Login a)
        {
            repositorio.Adicionar(a);
        }

        public List<Login> Listar()
        {
            return repositorio.listar();
        }
        public void editar(Login a)
        {
            repositorio.editar(a);
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }
    }
}
