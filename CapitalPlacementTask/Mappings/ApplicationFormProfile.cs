using AutoMapper;
using CapitalPlacementTask.DTOs;
using CapitalPlacementTask.Models;

namespace CapitalPlacementTask.Profiles
{
    public class ApplicationFormProfile : Profile
    {
        public ApplicationFormProfile()
        {
            CreateMap<ApplicationFormDTO, ApplicationForm>()
                .ForMember(dest => dest.ApplicationFormAdditionalQuestion, opt => opt.MapFrom(src => src.ApplicationFormAdditionalQuestion))
                .ForMember(dest => dest.PersonalInformation, opt => opt.MapFrom(src => src.PersonalInformation))
                .ForMember(dest => dest.ApplicationFormProfile, opt => opt.MapFrom(src => src.ApplicationFormProfile));

            CreateMap<ApplicationFormProfileDTO, ApplicationFormProfile>();

            CreateMap<ApplicationFormPersonalInformationDTO, ApplicationFormPersonalInformation>();

            CreateMap<ApplicationFormQuestionDTO, ApplicationFormQuestion>();

            CreateMap<ApplicationFormQuestionChoiceDTO, ApplicationFormQuestionChoice>();

            CreateMap<ApplicationFormQuestionMultipleChoiceDTO, ApplicationFormQuestionMultipleChoice>();

            CreateMap<ApplicationFormQuestionDropDownDTO, ApplicationFormQuestionDropDown>();

            CreateMap<ApplicationFormQuestionDropDownOptionDTO, ApplicationFormQuestionDropDownOption>();

            CreateMap<ApplicationFormQuestionYesOrNoDTO, ApplicationFormQuestionYesOrNo>();
        }
    }
}
