using Dapper.Contrib.Extensions;
using FrabalhoFinal._2_Repository.Interface;
using FrabalhoFinal._3_Entidade;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._2_Repository
{
    public class PessoaRepository : IPessoaRepository 
    {
        private readonly string ConnectionString;
        public PessoaRepository(string connectionString)
        {

            ConnectionString = connectionString;

        }
        public void Adicionar(Pessoa u)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Pessoa>(u);

        }
        public List<Pessoa> listar()
        {
            {
                using var connection = new SQLiteConnection(ConnectionString);
                {
                    List<Pessoa> u = connection.GetAll<Pessoa>().ToList();
                    return u;
                }
            }
        }
        public Pessoa Buscarporid(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Pessoa>(id);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Pessoa novoproduto = Buscarporid(id);
            connection.Delete<Pessoa>(novoproduto);
        }
        public void editar(Pessoa u)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Update<Pessoa>(u);
        }
    }
}

