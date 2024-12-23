﻿using FrabalhoFinal._1_Service.Interfaces;
using FrabalhoFinal._2_Repository;
using FrabalhoFinal._2_Repository.Interface;
using FrabalhoFinal._3_Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._1_Service
{
    public class ConteudoService : IConteudoService
    {
        IConteudoRepository repositorio { get; set; }
        public ConteudoService(IConteudoRepository conteudorepository)
        {
            repositorio = conteudorepository;
        }
        public void Adicionar(Conteudo a)
        {
            repositorio.Adicionar(a);
        }

        public List<Conteudo> Listar()
        {
            return repositorio.listar();
        }
        public void editar(Conteudo a)
        {
            repositorio.editar(a);
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }
    }
}

