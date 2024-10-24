using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Usecases
{
    public class PessoaUC
    {
        private readonly HttpClient _client;
        public PessoaUC(HttpClient cliente)
        {
            _client = cliente;
        }
        public List<PessoaUC> ListarCategoria(int usuarioId)
        {
            return _client.GetFromJsonAsync<List<PessoaUC>>("Pessoa/adicionar-Avaliação" + usuarioId).Result;
        }
        public PessoaUC CadastroCategoria(PessoaUC endereco)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Pessoa/adicionar-Avaliação", endereco).Result;

            PessoaUC enderecoCadastrado = response.Content.ReadFromJsonAsync<PessoaUC>().Result;
            return enderecoCadastrado;
        }
    }
}
