using AutoMapper;
using FrabalhoFinal._1_Service;
using FrabalhoFinal._1_Service.Interfaces;
using FrabalhoFinal._3_Entidade;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações de conteúdo.
    /// Fornece endpoints para criar, listar, editar e remover conteúdos.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ConteudoController : ControllerBase
    {
        private readonly IConteudoService service;
        private readonly IMapper mapper;

        /// <summary>
        /// Construtor do controlador. Inicializa o serviço de conteúdo e o mapeador AutoMapper.
        /// </summary>
        /// <param name="_mapper">Instância do AutoMapper para mapear objetos.</param>
        /// <param name="configuration">Configurações de aplicação, incluindo a string de conexão.</param>
        /// <param name="service">Serviço para manipulação de conteúdos.</param>
        public ConteudoController(IMapper _mapper, IConfiguration configuration, IConteudoService service)
        {
            // Recupera a string de conexão do arquivo de configuração (não utilizada diretamente no código atual)
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Inicializa o serviço de conteúdo com a instância recebida via injeção de dependência
            this.service = service;

            // Inicializa o mapeador AutoMapper
            this.mapper = _mapper;
        }

        /// <summary>
        /// Adiciona um novo conteúdo.
        /// Recebe um objeto de conteúdo e chama o serviço para adicioná-lo ao banco de dados.
        /// </summary>
        /// <param name="u">Objeto de conteúdo a ser adicionado.</param>
        [HttpPost("adicionar-Avaliação")]
        public IActionResult adicionaraluno(Conteudo u)
        {

            try
            {
                service.Adicionar(u);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest($"Ocorreu um erro ao adicionar endereco," +
                   $"o erro foi \n{erro.Message}");

            }
        }

        /// <summary>
        /// Retorna a lista de todos os conteúdos cadastrados.
        /// Chama o serviço para listar os conteúdos.
        /// </summary>
        /// <returns>Uma lista de objetos Conteudo.</returns>
        [HttpGet("Listar-Avaliações")]
        public List<Conteudo> Listaraluno()
        {
            // Chama o serviço para obter a lista de conteúdos
            return service.Listar();
        }

        /// <summary>
        /// Remove um conteúdo existente.
        /// Recebe o ID do conteúdo a ser removido e chama o serviço para removê-lo.
        /// </summary>
        /// <param name="id">ID do conteúdo a ser removido.</param>
        [HttpDelete("Remover-Avaliação")]
        public IActionResult Removeralunoaluno(int id)
        {
            // Chama o serviço para remover o conteúdo pelo ID
            service.Remover(id);
            return NoContent();
        }

        /// <summary>
        /// Edita um conteúdo existente.
        /// Recebe um objeto de conteúdo com os novos dados e chama o serviço para editar o conteúdo.
        /// </summary>
        /// <param name="usuario">Objeto de conteúdo com os novos dados.</param>
        [HttpPut("editar-Avaliação")]
        public IActionResult editaraluno(Conteudo usuario)
        {
            // Chama o serviço para editar o conteúdo
            service.editar(usuario);
            return NoContent();
        }
    }
}
