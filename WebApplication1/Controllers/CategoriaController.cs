using AutoMapper;
using FrabalhoFinal._1_Service;
using FrabalhoFinal._1_Service.Interfaces;
using FrabalhoFinal._3_Entidade;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações de categoria.
    /// Fornece endpoints para criar, listar, editar e remover categorias.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService service;
        private readonly IMapper mapper;

        /// <summary>
        /// Construtor do controlador. Inicializa o serviço de categoria e o mapeador AutoMapper.
        /// </summary>
        /// <param name="_mapper">Instância do AutoMapper para mapear objetos.</param>
        /// <param name="configuration">Configurações de aplicação, incluindo a string de conexão.</param>
        /// <param name="service">Serviço para manipulação de categorias.</param>
        public CategoriaController(IMapper _mapper, IConfiguration configuration, ICategoriaService service)
        {
            // Recupera a string de conexão do arquivo de configuração (não utilizada diretamente no código atual)
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Inicializa a variável service com a instância recebida via injeção de dependência
            this.service = service;

            // Inicializa o mapeador AutoMapper
            this.mapper = _mapper;
        }

        /// <summary>
        /// Adiciona uma nova categoria.
        /// Recebe um objeto de categoria e chama o serviço para adicioná-la ao banco de dados.
        /// </summary>
        /// <param name="u">Objeto de categoria a ser adicionado.</param>
        [HttpPost("adicionar-Avaliação")]
        public void adicionaraluno(Categoria u)
        {
            // Adiciona a categoria recebida ao banco de dados
            service.Adicionar(u);
        }

        /// <summary>
        /// Retorna a lista de todas as categorias cadastradas.
        /// Chama o serviço para listar as categorias.
        /// </summary>
        /// <returns>Uma lista de objetos Categoria.</returns>
        [HttpGet("Listar-Avaliações")]
        public List<Categoria> Listaraluno()
        {
            // Chama o serviço para obter a lista de categorias
            return service.Listar();
        }

        /// <summary>
        /// Remove uma categoria existente.
        /// Recebe o ID da categoria a ser removida e chama o serviço para removê-la.
        /// </summary>
        /// <param name="id">ID da categoria a ser removida.</param>
        [HttpDelete("Remover-Avaliação")]
        public void Removeralunoaluno(int id)
        {
            // Chama o serviço para remover a categoria pelo ID
            service.Remover(id);
        }

        /// <summary>
        /// Edita uma categoria existente.
        /// Recebe um objeto de categoria com os novos dados e chama o serviço para editar a categoria.
        /// </summary>
        /// <param name="usuario">Objeto de categoria com os novos dados.</param>
        [HttpPut("editar-Avaliação")]
        public void editaraluno(Categoria usuario)
        {
            // Chama o serviço para editar a categoria
            service.editar(usuario);
        }
    }
}
