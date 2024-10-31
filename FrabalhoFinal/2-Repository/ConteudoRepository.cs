using Dapper.Contrib.Extensions;
using FrabalhoFinal._2_Repository.Interface;
using FrabalhoFinal._3_Entidade;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._2_Repository
{
    public class ConteudoRepository : IConteudoRepository
    {
        private readonly string ConnectionString;
        public ConteudoRepository(IConfiguration configuration)
        {

            ConnectionString = configuration.GetConnectionString("DefaultConnection");

        }
        public void Adicionar(Conteudo u)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Conteudo>(u);

        }
        public List<Conteudo> listar()
        {
            {
                using var connection = new SQLiteConnection(ConnectionString);
                {
                    List<Conteudo> u = connection.GetAll<Conteudo>().ToList();
                    return u;
                }
            }
        }
        public Conteudo Buscarporid(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Conteudo>(id);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Conteudo novoproduto = Buscarporid(id);
            connection.Delete<Conteudo>(novoproduto);
        }
        public void editar(Conteudo u)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Update<Conteudo>(u);
        }
        public Conteudo BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Conteudo>(id);
        }
    }
}

