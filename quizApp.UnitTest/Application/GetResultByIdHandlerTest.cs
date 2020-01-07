using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using Moq;
using NUnit.Framework;
using quizApp.Application.Handlers;
using quizApp.Application.Queries;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.UnitTest.Application
{
    [TestFixture]
    public class GetResultByIdHandlerTest
    {
        private Mock<IRepositoryGeneric<QuizResult>> _mock;

        [SetUp]
        public void Init()
        {
            _mock = new Mock<IRepositoryGeneric<QuizResult>>();
            ObjectId tmp;
            _mock.Setup(r => r.FindByIdAsync(It.Is<string>(s => ObjectId.TryParse(s, out tmp))))
                .ReturnsAsync(new QuizResult());
            _mock.Setup(r => r.FindByIdAsync(It.Is<string>(s => !ObjectId.TryParse(s, out tmp))))
                .ReturnsAsync((QuizResult) null);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("bla-bla")]
        [TestCase("123")]
        public async Task IdInvalidResultNull(string id)
        {
            var query = new GetResultByIdQuery(id);
            var handler = new GetResultByIdHandler(_mock.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.IsNull(result);
        }

        [TestCase("5e08f0e631332ca005a642a5")]
        [TestCase("5e091ae71173cfc3e941e0e1")]
        [TestCase("5e091aef9ca69e7ab8efd574")]
        [TestCase("5e091afe38879c621f5d006b")]
        public async Task IdCorrect_ResultNotNull(string id)
        {
            var query = new GetResultByIdQuery(id);
            var handler = new GetResultByIdHandler(_mock.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.IsNotNull(result);
        }
    }
}