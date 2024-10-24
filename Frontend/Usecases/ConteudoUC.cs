using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Usecases
{
    public class ConteudoUC
    {
        private readonly HttpClient _client;
        public ConteudoUC(HttpClient cliente)
        {
            _client = cliente; 
        }
        public List<ConteudoUC> ListarCategoria(int usuarioId)
        {
            return _client.GetFromJsonAsync<List<ConteudoUC>>("Conteudo/Listar-Avaliações" + usuarioId).Result;
        }
        public ConteudoUC CadastroCategoria(ConteudoUC endereco)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Conteudo/adicionar-Avaliação", endereco).Result;

            ConteudoUC enderecoCadastrado = response.Content.ReadFromJsonAsync<ConteudoUC>().Result;
            return enderecoCadastrado;
        }
    }
}
