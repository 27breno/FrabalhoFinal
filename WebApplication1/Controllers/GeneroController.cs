using AutoMapper;
using FrabalhoFinal._1_Service;
using FrabalhoFinal._3_Entidade;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class GeneroController : ControllerBase
    {

        private readonly GeneroService service;
        private readonly IMapper mapper;
        public GeneroController(IMapper _mapper, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            service = new GeneroService(connectionString);
            mapper = _mapper;

        }

        [HttpPost("adicionar-Avaliação")]
        public void adicionaraluno(Genero u)
        {
            Genero usuario = mapper.Map<Genero>(u);
            service.Adicionar(usuario);
        }

        [HttpGet("Listar-Avaliações")]
        public List<Genero> Listaraluno()
        {
            return service.Listar();
        }
        [HttpDelete("Remover-Avaliação")]
        public void Removeralunoaluno(int id)
        {
            service.Remover(id);
        }
        [HttpPut("editar-Avaliação")]
        public void editaraluno(Genero usuario)
        {
            service.editar(usuario);
        }

    }
}
