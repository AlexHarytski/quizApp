using System.Collections.Generic;

namespace quizApp.Domain.Models
{
    public class QuizQuestion
    {
        public string Title { get; set; }
        public string Question { get; set; }
        public int Score { get; set; }
        public List<QuestionVariant> QuizVariant { get; set; }      
    }
}