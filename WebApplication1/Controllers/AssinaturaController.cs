using AutoMapper;
using FrabalhoFinal._1_Service;
using FrabalhoFinal._1_Service.Interfaces;
using FrabalhoFinal._3_Entidade;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações de assinatura.
    /// Fornece endpoints para criar, listar, editar e remover assinaturas.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AssinaturaController : ControllerBase
    {
        private readonly IAssinaturaService service;
        private readonly IMapper mapper;

        /// <summary>
        /// Construtor do controlador. Inicializa o serviço de assinatura e o mapeador AutoMapper.
        /// </summary>
        /// <param name="_mapper">Instância do AutoMapper para mapear objetos.</param>
        /// <param name="configuration">Configurações de aplicação, incluindo a string de conexão.</param>
        /// <param name="service">Serviço para manipulação de assinaturas.</param>
        public AssinaturaController(IMapper _mapper, IConfiguration configuration, IAssinaturaService service)
        {
            // Recupera a string de conexão do arquivo de configuração (não utilizada diretamente no código atual)
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Inicializa a variável service com a instância recebida via injeção de dependência
            this.service = service;

            // Inicializa o mapeador AutoMapper
            this.mapper = _mapper;
        }

        /// <summary>
        /// Adiciona uma nova assinatura.
        /// Recebe um objeto de assinatura e chama o serviço para adicioná-la ao banco de dados.
        /// </summary>
        /// <param name="u">Objeto de assinatura a ser adicionado.</param>
        [HttpPost("adicionar-Avaliação")]
        public void adicionaraluno(Assinatura u)
        {
            // Adiciona a assinatura recebida ao banco de dados
            service.Adicionar(u);
        }

        /// <summary>
        /// Retorna a lista de todas as assinaturas cadastradas.
        /// Chama o serviço para listar as assinaturas.
        /// </summary>
        /// <returns>Uma lista de objetos Assinatura.</returns>
        [HttpGet("Listar-Avaliações")]
        public List<Assinatura> Listaraluno()
        {
            // Chama o serviço para obter a lista de assinaturas
            return service.Listar();
        }

        /// <summary>
        /// Remove uma assinatura existente.
        /// Recebe o ID da assinatura a ser removida e chama o serviço para removê-la.
        /// </summary>
        /// <param name="id">ID da assinatura a ser removida.</param>
        [HttpDelete("Remover-Avaliação")]
        public void Removeralunoaluno(int id)
        {
            // Chama o serviço para remover a assinatura pelo ID
            service.Remover(id);
        }

        /// <summary>
        /// Edita uma assinatura existente.
        /// Recebe um objeto de assinatura com os novos dados e chama o serviço para editar a assinatura.
        /// </summary>
        /// <param name="usuario">Objeto de assinatura com os novos dados.</param>
        [HttpPut("editar-Avaliação")]
        public void editaraluno(Assinatura usuario)
        {
            // Chama o serviço para editar a assinatura
            service.editar(usuario);
        }
    }
}
