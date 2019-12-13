using System;
using MongoDB.Bson;

namespace quizApp.Domain.Models
{
    public class User
    {
        public ObjectId _id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Gender { get; set; }
        public DateTime DateRegistration { get; set; }
    }
}