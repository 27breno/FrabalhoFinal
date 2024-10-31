using Dapper.Contrib.Extensions;
using FrabalhoFinal._2_Repository.Interface;
using FrabalhoFinal._3_Entidade;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._2_Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly string ConnectionString;
        public CategoriaRepository(IConfiguration configuration)
        {

            ConnectionString = configuration.GetConnectionString("DefaultConnection");

        }
        public void Adicionar(Categoria u)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Categoria>(u);

        }
        public List<Categoria> listar()
        {
            {
                using var connection = new SQLiteConnection(ConnectionString);
                {
                    List<Categoria> u = connection.GetAll<Categoria>().ToList();
                    return u;
                }

            }

        }

        public Categoria Buscarporid(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Categoria>(id);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Categoria novoproduto = Buscarporid(id);
            connection.Delete<Categoria>(novoproduto);
        }
        public void editar(Categoria u)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Update<Categoria>(u);
        }
        public Categoria BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Categoria>(id);
        }
    }
}
