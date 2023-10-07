using CapitalPlacementTask.Enums;

namespace CapitalPlacementTask.Models
{
    public class ApplicationForm
    {
        public required string CoverImageUrl { get; set; }
        public required ApplicationFormPersonalInformation PersonalInformation { get; set; }
        public List<ApplicationFormProfile> ApplicationFormProfile { get; set; }
            = new List<ApplicationFormProfile>();
        public List<ApplicationFormQuestion> ApplicationFormAdditionalQuestion { get; set; }
            = new List<ApplicationFormQuestion>();
    }
    public class ApplicationFormProfile
    {
        public string QuestionText { get; set; } = null!;
        public bool IsMandatory { get; set; }
        public bool IsInternal { get; set; }
    }
    public class ApplicationFormPersonalInformation
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public List<ApplicationFormQuestion>? ApplicationFormQuestion { get; set; }
    }

    public class ApplicationFormQuestion
    {
        public QuestionType Type { get; set; }
        public string QuestionText { get; set; } = null!;
        public bool IsVisible { get; set; }
        public bool IsInternal { get; set; }
        public ApplicationFormQuestionMultipleChoice? ApplicationFormQuestionMultipleChoice { get; set; }
        public ApplicationFormQuestionDropDown? ApplicationFormQuestionDropDown { get; set; }
        public ApplicationFormQuestionYesOrNo? ApplicationFormQuestionYesOrNo { get; set; }
    }

    public class ApplicationFormQuestionMultipleChoice
    {
        public int MaxChoices { get; set; }
        public List<ApplicationFormQuestionChoice> Choices { get; set; }
            = new List<ApplicationFormQuestionChoice>();
    }

    public class ApplicationFormQuestionChoice
    {
        public string OptionText { get; set; } = null!;
    }

    public class ApplicationFormQuestionDropDown
    {
        public List<ApplicationFormQuestionDropDownOption> Options { get; set; }
            = new List<ApplicationFormQuestionDropDownOption>();
    }
    public class ApplicationFormQuestionDropDownOption
    {
        public string OptionText { get; set; } = null!;
    }

    public class ApplicationFormQuestionYesOrNo
    {
        public bool DisqualifyCandidate { get; set; }
    }
}
