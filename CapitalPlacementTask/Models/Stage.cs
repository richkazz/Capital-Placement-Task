using CapitalPlacementTask.Enums;

namespace CapitalPlacementTask.Models
{
    public class Stage
    {
        public required string StageName { get; set; }
        public StageTypeEnum StageType { get; set; }
        public List<VideoInterviewQuestion>? VideoInterviewQuestions { get; set; }
        public bool IsVisibleToCandidate { get; set; }
    }

    public class VideoInterviewQuestion
    {
        public required string QuestionText { get; set; }
        public string? AdditionalInformation { get; set; }
        public TimeSpan MaxVideoDuration { get; set; }
        public TimeSpan VideoSubmissionDeadline { get; set; }
    }
}
