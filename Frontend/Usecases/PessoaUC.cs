using FrabalhoFinal._3_Entidade;
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
        public List<PessoaUC> ListarPessoa(int usuarioId)
        {
            return _client.GetFromJsonAsync<List<PessoaUC>>("Pessoa/adicionar-Avaliação" + usuarioId).Result;
        }
        public PessoaUC CadastroPessoa(PessoaUC pessoa)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Pessoa/adicionar-Avaliação", pessoa).Result;

            PessoaUC enderecoCadastrado = response.Content.ReadFromJsonAsync<PessoaUC>().Result;
            return enderecoCadastrado;
        }

        internal Pessoa Login(string? nome, string? senha)
        {
            throw new NotImplementedException();
        }
    }
}
