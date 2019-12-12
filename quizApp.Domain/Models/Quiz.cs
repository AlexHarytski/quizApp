
using System.Collections.Generic;

namespace quizApp.Domain.Models
{
    class Quiz
    {
        public string Id { get; set; }
        public string QuizType { get; set; }
        public string Description { get; set; }
        public List<QuizQuestion> Questions { get; set; }
    }
}
