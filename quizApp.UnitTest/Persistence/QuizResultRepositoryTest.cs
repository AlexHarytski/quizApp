using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.UnitTest.Persistence
{
    [TestFixture]
    public class QuizResultRepositoryTest
    {
        [Test]
        public void GetAllQuizResult()
        {
            var mock = new Mock<IMongoCollection<Quiz>>();
        }
        
    }
}