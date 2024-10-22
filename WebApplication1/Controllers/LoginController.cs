using AutoMapper;
using FrabalhoFinal._1_Service;
using FrabalhoFinal._3_Entidade;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly LoginService service;
        private readonly IMapper mapper;
        public LoginController(IMapper _mapper, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            service = new LoginService(connectionString);
            mapper = _mapper;

        }

        [HttpPost("adicionar-Avaliação")]
        public void adicionaraluno(Login u)
        {
            //Conteudo usuario = mapper.Map<Conteudo>(u);
            service.Adicionar(u);
        }

        [HttpGet("Listar-Avaliações")]
        public List<Login> Listaraluno()
        {
            return service.Listar();
        }
        [HttpDelete("Remover-Avaliação")]
        public void Removeralunoaluno(int id)
        {
            service.Remover(id);
        }
        [HttpPut("editar-Avaliação")]
        public void editaraluno(Login usuario)
        {
            service.editar(usuario);
        }
    }
}
