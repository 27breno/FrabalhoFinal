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
    public class AssinaturaRepository : IAssinaturaRepository
    {

        private readonly string ConnectionString;
        public AssinaturaRepository(IConfiguration configuration)
        {

            ConnectionString = configuration.GetConnectionString("DefaultConnection");

        }
        public void Adicionar(Assinatura u)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Assinatura>(u);

        }
        public List<Assinatura> listar()
        {
            {
                using var connection = new SQLiteConnection(ConnectionString);
                {
                    List<Assinatura> u = connection.GetAll<Assinatura>().ToList();
                    return u;
                }
                
            }
            
        }
          
        public Assinatura Buscarporid(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Assinatura>(id);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Assinatura novoproduto = Buscarporid(id);
            connection.Delete<Assinatura>(novoproduto);
        }
        public void editar(Assinatura u)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Update<Assinatura>(u);
        }
    }
}
