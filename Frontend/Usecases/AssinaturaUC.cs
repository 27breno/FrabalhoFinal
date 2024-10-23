using FrabalhoFinal._3_Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Usecases
{
    public class AssinaturaUC
    {
        private readonly HttpClient _client;
        public AssinaturaUC(HttpClient cliente)
        {
            _client = cliente;
        }
        public List<Assinatura> ListarAssinaturas(int usuarioId)
        {
            return _client.GetFromJsonAsync<List<Assinatura>>("Assinatura/Listar-Avaliações" + usuarioId).Result;
        }
        public Assinatura CadastroAssinatura(Assinatura endereco)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Assinatura/adicionar-Avaliação", endereco).Result;

            Assinatura enderecoCadastrado = response.Content.ReadFromJsonAsync<Assinatura>().Result;
            return enderecoCadastrado;
        }
    }
}
