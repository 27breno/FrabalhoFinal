using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Usecases
{
    public class CategoriaUC
    {
        private readonly HttpClient _client;
        public CategoriaUC(HttpClient cliente)
        {
            _client = cliente;
        }
        public List<CategoriaUC> ListarCategoria(int usuarioId)
        {
            return _client.GetFromJsonAsync<List<CategoriaUC>>("Avaliacao/Listar-Avaliações" + usuarioId).Result;
        }
        public  CategoriaUC CadastroCategoria(CategoriaUC endereco)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Avaliacao/adicionar-Avaliação", endereco).Result;

            CategoriaUC enderecoCadastrado = response.Content.ReadFromJsonAsync<CategoriaUC>().Result;
            return enderecoCadastrado;
        }
    }
}
