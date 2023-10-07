using CapitalPlacementTask.Enums;

namespace CapitalPlacementTask.DTOs
{
    public class StageDTO
    {
        public required string StageName { get; set; }
        public StageTypeEnum StageType { get; set; }
        public List<VideoInterviewQuestionDTO>? VideoInterviewQuestions { get; set; }
        public bool IsVisibleToCandidate { get; set; }
    }

    public class VideoInterviewQuestionDTO
    {
        public required string QuestionText { get; set; }
        public string? AdditionalInformation { get; set; }
        public TimeSpan MaxVideoDuration { get; set; }
        public TimeSpan VideoSubmissionDeadline { get; set; }
    }
}

