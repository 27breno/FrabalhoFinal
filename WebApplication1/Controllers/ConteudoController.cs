using AutoMapper;
using FrabalhoFinal._1_Service;
using FrabalhoFinal._1_Service.Interfaces;
using FrabalhoFinal._3_Entidade;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class ConteudoController : ControllerBase
    {

        private readonly IConteudoService service;
        private readonly IMapper mapper;
        public ConteudoController(IMapper _mapper, IConfiguration configuration, IConteudoService service)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            service = service;
            mapper = _mapper;

        }

        [HttpPost("adicionar-Avaliação")]
        public void adicionaraluno(Conteudo u)
        {
            //Conteudo usuario = mapper.Map<Conteudo>(u);
            service.Adicionar(u);
        }

        [HttpGet("Listar-Avaliações")]
        public List<Conteudo> Listaraluno()
        {
            return service.Listar();
        }
        [HttpDelete("Remover-Avaliação")]
        public void Removeralunoaluno(int id)
        {
            service.Remover(id);
        }
        [HttpPut("editar-Avaliação")]
        public void editaraluno(Conteudo usuario)
        {
            service.editar(usuario);
        }

    }
}
