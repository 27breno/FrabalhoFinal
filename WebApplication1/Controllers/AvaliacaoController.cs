using AutoMapper;
using FrabalhoFinal._1_Service;
using FrabalhoFinal._1_Service.Interfaces;
using FrabalhoFinal._3_Entidade;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas à Avaliação.
    /// Fornece endpoints para criar, listar, editar e remover avaliações.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService service;
        private readonly IMapper mapper;

        /// <summary>
        /// Construtor do controlador. Inicializa o serviço de avaliação e o mapeador AutoMapper.
        /// </summary>
        /// <param name="_mapper">Instância do AutoMapper para mapear objetos.</param>
        /// <param name="configuration">Configurações de aplicação, incluindo a string de conexão.</param>
        /// <param name="service">Serviço para manipulação de avaliações.</param>
        public AvaliacaoController(IMapper _mapper, IConfiguration configuration, IAvaliacaoService service)
        {
            // Recupera a string de conexão do arquivo de configuração
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Inicializa a variável service com a instância recebida via injeção de dependência
            this.service = service;

            // Inicializa o mapeador AutoMapper
            this.mapper = _mapper;
        }

        /// <summary>
        /// Adiciona uma nova avaliação.
        /// Recebe um objeto de avaliação, mapeia para o tipo correto e chama o serviço para adicionar.
        /// </summary>
        /// <param name="u">Objeto de avaliação a ser adicionado.</param>
        [HttpPost("adicionar-Avaliação")]
        public void adicionaraluno(Avaliacao u)
        {
            // Mapeia a avaliação recebida para o modelo de entidade Avaliacao
            Avaliacao usuario = mapper.Map<Avaliacao>(u);

            // Chama o serviço para adicionar a avaliação
            service.Adicionar(usuario);
        }

        /// <summary>
        /// Retorna a lista de todas as avaliações cadastradas.
        /// Chama o serviço para listar as avaliações.
        /// </summary>
        /// <returns>Uma lista de objetos Avaliacao.</returns>
        [HttpGet("Listar-Avaliações")]
        public List<Avaliacao> Listaraluno()
        {
            // Chama o serviço para obter a lista de avaliações
            return service.Listar();
        }

        /// <summary>
        /// Remove uma avaliação existente.
        /// Recebe o ID da avaliação a ser removida e chama o serviço para removê-la.
        /// </summary>
        /// <param name="id">ID da avaliação a ser removida.</param>
        [HttpDelete("Remover-Avaliação")]
        public void Removeralunoaluno(int id)
        {
            // Chama o serviço para remover a avaliação pelo ID
            service.Remover(id);
        }

        /// <summary>
        /// Edita uma avaliação existente.
        /// Recebe um objeto de avaliação com os novos dados e chama o serviço para editar a avaliação.
        /// </summary>
        /// <param name="usuario">Objeto de avaliação com os novos dados.</param>
        [HttpPut("editar-Avaliação")]
        public void editaraluno(Avaliacao usuario)
        {
            // Chama o serviço para editar a avaliação
            service.editar(usuario);
        }
    }
}
