﻿using AutoMapper;
using FrabalhoFinal._1_Service;
using FrabalhoFinal._3_Entidade;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class GeneroController : ControllerBase
    {

        private readonly ConteudoService service;
        private readonly IMapper mapper;
        public GeneroController(IMapper _mapper, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            service = new ConteudoService(connectionString);
            mapper = _mapper;

        }

        [HttpPost("adicionar-Avaliação")]
        public void adicionaraluno(Conteudo u)
        {
            Conteudo usuario = mapper.Map<Conteudo>(u);
            service.Adicionar(usuario);
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
