using MongoDB.Bson;

namespace quizApp.Domain.Models
{
    public class QuizResult
    {
        public ObjectId _id { get; set; }
        public ObjectId QuizId { get; set; }
        public ObjectId UserId { get; set; }
        public int UserScore { get; set; }
    }
}