using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace quizApp.Domain.Models
{
    public class Quiz
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string Title { get; set; }
        public string QuizType { get; set; }
        public List<QuizQuestion> QuizQuestion { get; set; }
    }
}
