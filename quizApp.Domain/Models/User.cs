using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace quizApp.Domain.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime DateRegistration { get; set; }
    }
}