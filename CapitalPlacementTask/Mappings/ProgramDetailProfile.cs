using AutoMapper;
using CapitalPlacementTask.DTOs;
using CapitalPlacementTask.Models;

namespace CapitalPlacementTask.Mappings
{
    public class ProgramDetailProfile : Profile
    {
        public ProgramDetailProfile()
        {
            CreateMap<ProgramDetailDTO, ProgramDetail>();
        }
    }
}
