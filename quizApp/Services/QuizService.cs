using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.Services
{
    public class QuizService
    {
        private QuizUOW uow;

        public QuizService(IQuizDatabaseSettings settings)
        {
            uow = new QuizUOW(settings);
        }

        public List<Quiz> GetQuizzes() => uow.QuizRepository.GetList();
        public List<User> GetUsers() => uow.UserRepository.GetList();
        public List<QuizResult> GerResults() => uow.QuizResultRepository.GetList();
    }
}
