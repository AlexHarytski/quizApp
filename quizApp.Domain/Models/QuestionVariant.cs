namespace quizApp.Domain.Models
{
    public class QuestionVariant
    {
        public string Id { get; set; }
        public string VariantText { get; set; }
        public bool IsCorrect { get; set; }
    }
}