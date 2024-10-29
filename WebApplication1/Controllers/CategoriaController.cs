using AutoMapper;
using FrabalhoFinal._1_Service;
using FrabalhoFinal._1_Service.Interfaces;
using FrabalhoFinal._3_Entidade;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {

        private readonly ICategoriaService service;
        private readonly IMapper mapper;
        public CategoriaController(IMapper _mapper, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            service = new CategoriaService(connectionString);
            mapper = _mapper;

        }

        [HttpPost("adicionar-Avaliação")]
        public void adicionaraluno(Categoria u)
        {
            //Conteudo usuario = mapper.Map<Conteudo>(u);
            service.Adicionar(u);
        }

        [HttpGet("Listar-Avaliações")]
        public List<Categoria> Listaraluno()
        {
            return service.Listar();
        }
        [HttpDelete("Remover-Avaliação")]
        public void Removeralunoaluno(int id)
        {
            service.Remover(id);
        }
        [HttpPut("editar-Avaliação")]
        public void editaraluno(Categoria usuario)
        {
            service.editar(usuario);
        }
    }
}
