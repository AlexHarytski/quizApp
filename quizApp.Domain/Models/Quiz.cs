using System.Collections.Generic;
using MongoDB.Bson;

namespace quizApp.Domain.Models
{
    public class Quiz
    {
        public ObjectId _id { get; set; }
        public string QuizType { get; set; }
        public string Description { get; set; }
        public List<QuizQuestion> Questions { get; set; }
    }
}
