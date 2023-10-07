using AutoMapper;
using CapitalPlacementTask.DTOs;
using CapitalPlacementTask.Models;

namespace CapitalPlacementTask.Profiles
{
    public class StageProfile : Profile
    {
        public StageProfile()
        {

            CreateMap<StageDTO, Stage>()
                .ForMember(dest => dest.VideoInterviewQuestions, opt => opt.MapFrom(src => src.VideoInterviewQuestions));

            CreateMap<VideoInterviewQuestionDTO, VideoInterviewQuestion>();
        }
    }
}
