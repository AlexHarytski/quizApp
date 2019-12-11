namespace quizApp.Domain.Models
{
    public class QuizQuestion
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Question { get; set; }
        public int Score { get; set; }
        public string QuizId { get; set; }
    }
}