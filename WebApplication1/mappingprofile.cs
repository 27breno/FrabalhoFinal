using AutoMapper;
using FrabalhoFinal._3_Entidade;
using FrabalhoFinal._3_Entidade.DTO.FIlme;
using FrabalhoFinal._3_Entidade.DTO.Genero;
using FrabalhoFinal._3_Entidade.DTO.Pessoa;

namespace WebApplication1
{
    public class mappingprofile:Profile
    {
        public mappingprofile()
        {
            CreateMap<CreateFilme, Filme>().ReverseMap();
            CreateMap<CreateGenero, Genero>().ReverseMap();
            CreateMap<CreatePessoa, Pessoa>().ReverseMap();
        }
    }
}
