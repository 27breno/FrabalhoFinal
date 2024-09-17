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
    public class FilmeRepository
    {
        private readonly string ConnectionString;
        public FilmeRepository(string connectionString)
        {

            ConnectionString = connectionString;

        }
        public void Adicionar(Filme u)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Filme>(u);

        }
        public List<Filme> listar()
        {
            {
                using var connection = new SQLiteConnection(ConnectionString);
                {
                    List<Filme> u = connection.GetAll<Filme>().ToList();
                    return u;
                }
            }
        }
        public Filme Buscarporid(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Filme>(id);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Filme novoproduto = Buscarporid(id);
            connection.Delete<Filme>(novoproduto);
        }
        public void editar(Filme u)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Update<Filme>(u);
        }
    }



}

