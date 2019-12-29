using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using quizApp.Application.Handlers;
using quizApp.Application.Queries;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.UnitTest.Application
{
    [TestFixture]
    public class GetAllResultsHandlerTest
    {
        private Mock<IRepositoryGeneric<QuizResult>> _mock;

        [SetUp]
        public void Init()
        {
            _mock = new Mock<IRepositoryGeneric<QuizResult>>();
            _mock.Setup(r => r.GetListAsync())
                .ReturnsAsync(new List<QuizResult>
                {
                    new QuizResult(),
                    new QuizResult(),
                    new QuizResult()
                });
        }

        [Test]
        public async Task ListNotNull()
        {
            var query = new GetAllResultsQuery();
            var handler = new GetAllResultsHandler(_mock.Object);

            var result = await handler.Handle(query, CancellationToken.None);
            
            Assert.NotNull(result);
        }

        [Test]
        public async Task Get3Results()
        {
            var query = new GetAllResultsQuery();
            var handler = new GetAllResultsHandler(_mock.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.AreEqual(result.Count, 3);
        }

    }
}