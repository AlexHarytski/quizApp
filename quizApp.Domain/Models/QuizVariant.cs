namespace quizApp.Domain.Models
{
    public class QuizVariant
    {
        public string Id { get; set; }
        public string VariantText { get; set; }
        public bool IsCorrect { get; set; }
        public string QuizQuestionId { get; set; }
    }
}