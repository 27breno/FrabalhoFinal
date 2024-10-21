using AutoMapper;
using FrabalhoFinal._3_Entidade;
using FrabalhoFinal._3_Entidade.DTO.Assinatura;
using FrabalhoFinal._3_Entidade.DTO.Avaliacao;
using FrabalhoFinal._3_Entidade.DTO.Genero;
using FrabalhoFinal._3_Entidade.DTO.Pessoas;

namespace WebApplication1
{
    public class mappingprofile:Profile
    {
        public mappingprofile()
        {
            CreateMap<CreateAssinatura, Assinatura>().ReverseMap();
            CreateMap<CreateAvaliacao, Avaliacao>().ReverseMap();
            CreateMap<CreateConteudo, Conteudo>().ReverseMap();
            CreateMap<CreatePessoa, Pessoa>().ReverseMap();
        }
    }
}
