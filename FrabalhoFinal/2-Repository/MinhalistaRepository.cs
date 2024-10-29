using Dapper;
using Dapper.Contrib.Extensions;
using FrabalhoFinal._3_Entidade;
using FrabalhoFinal._3_Entidade.DTO.MinhaLista;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._2_Repository
{
    public class MinhalistaRepository
    {
        private readonly string ConnectionString;
        private readonly AssinaturaRepository _repositoryAssinatura;
        private readonly AvaliacaoRepository _repositoryAvaliacao;
 
        public MinhalistaRepository(string connectioString)
        {
            ConnectionString = connectioString;
            _repositoryAssinatura = new AssinaturaRepository(connectioString);
            _repositoryAvaliacao = new AvaliacaoRepository(connectioString);
            
        }
        public void Adicionar(MinhaLista carrinho)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<MinhaLista>(carrinho);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            MinhaLista carrinho = BuscarPorId(id);
            connection.Delete<MinhaLista>(carrinho);
        }
        public void Editar(MinhaLista carrinho)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Update<MinhaLista>(carrinho);
        }
        public List<MinhaLista> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            List<MinhaLista> list = connection.GetAll<MinhaLista>().ToList();
            
            return list;
        }

        private List<DTOminhalista> TransformarListaMInhaListaEmListaDTO(List<MinhaLista> list)
        {
            List<DTOminhalista> listDTO = new List<DTOminhalista>();

            foreach (MinhaLista car in list)
            {
                DTOminhalista readCarrinho = new DTOminhalista();
                readCarrinho.CategoriaId = _repositoryAssinatura.BuscarPorId(car.Categoria);
                readCarrinho.ConteudoId  = _repositoryAvaliacao.BuscarPorId(car.Conteudo);
                listDTO.Add(readCarrinho);
            }
            return listDTO;
        }

        public List<DTOminhalista> ListarMinhaListaDoUsuario(int usuarioId)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            List<MinhaLista> list = connection.Query<MinhaLista>($"SELECT Id, UsuarioId, ProdutoId FROM Carrinhos WHERE UsuarioId = {usuarioId}").ToList();
            List<DTOminhalista> listDTO = TransformarListaMInhaListaEmListaDTO(list);
            return listDTO;
        }
        public MinhaLista BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<MinhaLista>(id);
        }
    }
}
