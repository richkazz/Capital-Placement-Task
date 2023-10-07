using CapitalPlacementTask.Enums;

namespace CapitalPlacementTask.Models
{
    public class ProgramDetail : EntityBase
    {
        public required string ProgramTitle { get; set; }
        public string? ProgramSummary { get; set; }
        public required string ProgramDescription { get; set; }
        public List<string>? SkillsNeeded { get; set; }
        public string? ProgramBenefits { get; set; }
        public string? ApplicationCriteria { get; set; }
        public ProgramTypeEnum ProgramType { get; set; }
        public DateTime? ProgramStart { get; set; }
        public DateTime ApplicationOpen { get; set; }
        public DateTime ApplicationClose { get; set; }
        public string? Duration { get; set; }
        public required string ProgramLocation { get; set; }
        public bool IsRemote { get; set; }
        public MinimumQualificationEnum? MinimumQualification { get; set; }
        public int? MaximumApplication { get; set; }
    }
}
