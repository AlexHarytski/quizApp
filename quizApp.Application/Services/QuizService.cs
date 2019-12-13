using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.Application.Services
{
    public class QuizService
    {
        public QuizRepository Quizzes { get; set; }
        public UserRepository Users { get; set; }
        public QuizResultRepository QuizResults { get; set; }

        public QuizService(IQuizDatabaseSettings settings)
        {
            Quizzes = new QuizRepository(settings);
            Users = new UserRepository(settings);
            QuizResults = new QuizResultRepository(settings);
        }

        public List<Quiz> GetQuizzes() => Quizzes.GetList();
        public List<User> GetUsers() => Users.GetList();
        public List<QuizResult> GerResults() => QuizResults.GetList();
    }
}
