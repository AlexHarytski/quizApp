using System.Collections.Generic;

namespace quizApp.Domain.Models
{
    public class QuizQuestion
    {
        public string Title { get; set; }
        public string Question { get; set; }
        public int Score { get; set; }
        public string QuizId { get; set; }
        public List<QuestionVariant> Variants { get; set; }      
    }
}