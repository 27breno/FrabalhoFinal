using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Usecases
{
    public class AvaliacaoUC
    {
        private readonly HttpClient _client;
        public AvaliacaoUC(HttpClient cliente)
        {
            _client = cliente;
        }
        public List<Avaliacao> ListarAssinaturas(int usuarioId)
        {
            return _client.GetFromJsonAsync<List<Avaliacao>>("Avaliacao/Listar-Avaliações" + usuarioId).Result;
        }
        public Avaliacao CadastroAssinatura(Avaliacao endereco)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Avaliacao/adicionar-Avaliação", endereco).Result;

            Avaliacao enderecoCadastrado = response.Content.ReadFromJsonAsync<Avaliacao>().Result;
            return enderecoCadastrado;
        }
    }
}
