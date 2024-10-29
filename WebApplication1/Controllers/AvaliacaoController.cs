using AutoMapper;
using FrabalhoFinal._1_Service;
using FrabalhoFinal._1_Service.Interfaces;
using FrabalhoFinal._3_Entidade;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService service;
        private readonly IMapper mapper;
        public AvaliacaoController(IMapper _mapper, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            service = new AvaliacaoService(connectionString);
            mapper = _mapper;

        }

        [HttpPost("adicionar-Avaliação")]
        public void adicionaraluno(Avaliacao u)
        {
            Avaliacao usuario = mapper.Map<Avaliacao>(u);
            service.Adicionar(usuario);
        }

        [HttpGet("Listar-Avaliações")]
        public List<Avaliacao> Listaraluno()
        {
            return service.Listar();
        }
        [HttpDelete("Remover-Avaliação")]
        public void Removeralunoaluno(int id)
        {
            service.Remover(id);
        }
        [HttpPut("editar-Avaliação")]
        public void editaraluno(Avaliacao usuario)
        {
            service.editar(usuario);
        }
    }
}
