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
    public class GeneroRepository
    {
        private readonly string ConnectionString;
        public GeneroRepository(string connectionString)
        {

            ConnectionString = connectionString;

        }
        public void Adicionar(Genero u)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Genero>(u);

        }
        public List<Genero> listar()
        {
            {
                using var connection = new SQLiteConnection(ConnectionString);
                {
                    List<Genero> u = connection.GetAll<Genero>().ToList();
                    return u;
                }
            }
        }
        public Genero Buscarporid(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Genero>(id);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Genero novoproduto = Buscarporid(id);
            connection.Delete<Genero>(novoproduto);
        }
        public void editar(Genero u)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Update<Genero>(u);
        }
    }
}

