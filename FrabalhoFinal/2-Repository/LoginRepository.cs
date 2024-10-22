using Dapper.Contrib.Extensions;
using FrabalhoFinal._3_Entidade;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._2_Repository
{
    public class LoginRepository
    {
        private readonly string ConnectionString;
        public LoginRepository(string connectionString)
        {

            ConnectionString = connectionString;

        }
        public void Adicionar(Login u)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Login>(u);

        }
        public List<Login> listar()
        {
            {
                using var connection = new SQLiteConnection(ConnectionString);
                {
                    List<Login> u = connection.GetAll<Login>().ToList();
                    return u;
                }

            }

        }

        public Login Buscarporid(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Login>(id);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Login novoproduto = Buscarporid(id);
            connection.Delete<Login>(novoproduto);
        }
        public void editar(Login u)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Update<Login>(u);
        }
    }
}
