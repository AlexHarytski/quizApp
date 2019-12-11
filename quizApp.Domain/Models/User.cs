using System;

namespace quizApp.Domain.Models
{
    public class User
    {
        //
        public string Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Gender { get; set; }
        public DateTime DateRegistration { get; set; }
    }
}