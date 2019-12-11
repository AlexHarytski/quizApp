namespace quizApp.Domain.Models
{
    public class QuizResult
    {
        public string Id { get; set; }
        public string QuizId { get; set; }
        public string UserId { get; set; }
        public int UserScore { get; set; }
    }
}