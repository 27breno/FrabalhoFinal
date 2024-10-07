using AutoMapper;
using FrabalhoFinal._3_Entidade;
using FrabalhoFinal._3_Entidade.DTO.Assinatura;
using FrabalhoFinal._3_Entidade.DTO.FIlme;
using FrabalhoFinal._3_Entidade.DTO.Genero;
using FrabalhoFinal._3_Entidade.DTO.Pessoas;

namespace WebApplication1
{
    public class mappingprofile:Profile
    {
        public mappingprofile()
        {
            CreateMap<CreateAssinatura, Assinatura>().ReverseMap();
            CreateMap<CreateFilme, Filme>().ReverseMap();
            CreateMap<CreateConteudo, Conteudo>().ReverseMap();
            CreateMap<CreatePessoa, Pessoa>().ReverseMap();
        }
    }
}
