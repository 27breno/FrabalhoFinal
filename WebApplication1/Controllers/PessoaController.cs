using AutoMapper;
using FrabalhoFinal._1_Service;
using FrabalhoFinal._1_Service.Interfaces;
using FrabalhoFinal._3_Entidade;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações de pessoa.
    /// Fornece endpoints para criar, listar, editar e remover pessoas.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService service;
        private readonly IMapper mapper;

        /// <summary>
        /// Construtor do controlador. Inicializa o serviço de pessoa e o mapeador AutoMapper.
        /// </summary>
        /// <param name="_mapper">Instância do AutoMapper para mapear objetos.</param>
        /// <param name="configuration">Configurações de aplicação, incluindo a string de conexão.</param>
        /// <param name="service">Serviço para manipulação de pessoas.</param>
        public PessoaController(IMapper _mapper, IConfiguration configuration, IPessoaService service)
        {
            // Recupera a string de conexão do arquivo de configuração (não utilizada diretamente no código atual)
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Inicializa o serviço de pessoa com a instância recebida via injeção de dependência
            this.service = service;

            // Inicializa o mapeador AutoMapper
            this.mapper = _mapper;
        }

        /// <summary>
        /// Adiciona uma nova pessoa.
        /// Recebe um objeto de pessoa e chama o serviço para adicioná-la ao banco de dados.
        /// </summary>
        /// <param name="u">Objeto de pessoa a ser adicionado.</param>
        [HttpPost("adicionar-Avaliação")]
        public IActionResult adicionaraluno(Pessoa u)
        {
            // Mapeia o objeto recebido para a entidade Pessoa (se necessário)
            Pessoa usuario = mapper.Map<Pessoa>(u);

            try
            {
                service.Adicionar(usuario);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest($"Ocorreu um erro ao adicionar endereco," +
                   $"o erro foi \n{erro.Message}");

            }


        }

        /// <summary>
        /// Retorna a lista de todas as pessoas cadastradas.
        /// Chama o serviço para listar as pessoas.
        /// </summary>
        /// <returns>Uma lista de objetos Pessoa.</returns>
        [HttpGet("Listar-Avaliações")]
        public List<Pessoa> Listaraluno()
        {
            // Chama o serviço para obter a lista de pessoas
            return service.Listar();
        }

        /// <summary>
        /// Remove uma pessoa existente.
        /// Recebe o ID da pessoa a ser removida e chama o serviço para removê-la.
        /// </summary>
        /// <param name="id">ID da pessoa a ser removida.</param>
        [HttpDelete("Remover-Avaliação")]
        public IActionResult Removeralunoaluno(int id)
        {
            // Chama o serviço para remover a pessoa pelo ID
            service.Remover(id);
            return NoContent();
        }

        /// <summary>
        /// Edita uma pessoa existente.
        /// Recebe um objeto de pessoa com os novos dados e chama o serviço para editar a pessoa.
        /// </summary>
        /// <param name="usuario">Objeto de pessoa com os novos dados.</param>
        [HttpPut("editar-Avaliação")]
        public IActionResult editaraluno(Pessoa usuario)
        {
            // Chama o serviço para editar a pessoa
            service.editar(usuario);
            return NoContent();
        }
    }
}
