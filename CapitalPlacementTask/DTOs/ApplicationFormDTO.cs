using CapitalPlacementTask.Enums;
using CapitalPlacementTask.Models;
using System.ComponentModel.DataAnnotations;

namespace CapitalPlacementTask.DTOs
{
    public class ApplicationFormDTO
    {
        public string CoverImageUrl { get; set; } = null!;
        public required ApplicationFormPersonalInformationDTO PersonalInformation { get; set; }
        public List<ApplicationFormProfileDTO> ApplicationFormProfile { get; set; }
        public List<ApplicationFormQuestion> ApplicationFormAdditionalQuestion { get; set; }
    }
    public class ApplicationFormProfileDTO
    {
        [Required]
        public string QuestionText { get; set; } = null!;
        public bool IsMandatory { get; set; }
        public bool IsInternal { get; set; }
    }
    public class ApplicationFormPersonalInformationDTO
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public List<ApplicationFormQuestion> ApplicationFormQuestion { get; set; } = new List<ApplicationFormQuestion>();
    }

    public class ApplicationFormQuestionDTO
    {
        [Required]
        public QuestionType Type { get; set; }
        [Required]
        public string QuestionText { get; set; } = null!;
        public bool IsVisible { get; set; }
        public bool IsInternal { get; set; }
        public ApplicationFormQuestionMultipleChoiceDTO? ApplicationFormQuestionMultipleChoice { get; set; }
        public ApplicationFormQuestionDropDownDTO? ApplicationFormQuestionDropDown { get; set; }
        public ApplicationFormQuestionYesOrNoDTO? ApplicationFormQuestionYesOrNo { get; set; }
    }

    public class ApplicationFormQuestionMultipleChoiceDTO
    {
        public int MaxChoices { get; set; }
        public List<ApplicationFormQuestionChoiceDTO> Choices { get; set; }
            = new List<ApplicationFormQuestionChoiceDTO>();
    }

    public class ApplicationFormQuestionChoiceDTO
    {
        [Required]
        public string OptionText { get; set; } = null!;
    }

    public class ApplicationFormQuestionDropDownDTO
    {
        public List<ApplicationFormQuestionDropDownOptionDTO> Options { get; set; }
            = new List<ApplicationFormQuestionDropDownOptionDTO>();
    }
    public class ApplicationFormQuestionDropDownOptionDTO
    {
        [Required]
        public string OptionText { get; set; } = null!;
    }

    public class ApplicationFormQuestionYesOrNoDTO
    {
        public bool DisqualifyCandidate { get; set; }
    }
}
