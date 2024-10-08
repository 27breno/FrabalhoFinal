﻿using AutoMapper;
using FrabalhoFinal._1_Service;
using FrabalhoFinal._3_Entidade;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AssinaturaController : ControllerBase
    {

        private readonly AssinaturaService service;
        private readonly IMapper mapper;
        public AssinaturaController(IMapper _mapper, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            service = new AssinaturaService(connectionString);
            mapper = _mapper;

        }

        [HttpPost("adicionar-Avaliação")]
        public void adicionaraluno(Assinatura u)
        {
            //Conteudo usuario = mapper.Map<Conteudo>(u);
            service.Adicionar(u);
        }

        [HttpGet("Listar-Avaliações")]
        public List<Assinatura> Listaraluno()
        {
            return service.Listar();
        }
        [HttpDelete("Remover-Avaliação")]
        public void Removeralunoaluno(int id)
        {
            service.Remover(id);
        }
        [HttpPut("editar-Avaliação")]
        public void editaraluno(Assinatura usuario)
        {
            service.editar(usuario);
        }

    }
}
    
