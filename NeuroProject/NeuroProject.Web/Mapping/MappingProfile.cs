using AutoMapper;
using NeuroProject.BLL.BusinessModels;
using NeuroProject.Web.Dto;

namespace NeuroProject.Web.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateResearchDto, ResearchBm>();
    }
}