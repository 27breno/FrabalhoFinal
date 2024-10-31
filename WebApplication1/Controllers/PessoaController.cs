﻿using AutoMapper;
using FrabalhoFinal._1_Service;
using FrabalhoFinal._1_Service.Interfaces;
using FrabalhoFinal._3_Entidade;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    
        [ApiController]
        [Route("[controller]")]
        public class PessoaController : ControllerBase
        {

            private readonly IPessoaService service;
            private readonly IMapper mapper;
            public PessoaController(IMapper _mapper, IConfiguration configuration, IPessoaService service)
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                service = service;
                mapper = _mapper;

            }

            [HttpPost("adicionar-Avaliação")]
            public void adicionaraluno(Pessoa u)
            {
            Pessoa usuario = mapper.Map<Pessoa>(u);
                service.Adicionar(usuario);
            }

            [HttpGet("Listar-Avaliações")]
            public List<Pessoa> Listaraluno()
            {
                return service.Listar();
            }
            [HttpDelete("Remover-Avaliação")]
            public void Removeralunoaluno(int id)
            {
                service.Remover(id);
            }
            [HttpPut("editar-Avaliação")]
            public void editaraluno(Pessoa usuario)
            {
                service.editar(usuario);
            }
        }
}
