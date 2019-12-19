using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace quizApp.Domain.Models
{
    public class QuizResult
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string QuizId { get; set; }
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }
        public int UserScore { get; set; }
    }
}