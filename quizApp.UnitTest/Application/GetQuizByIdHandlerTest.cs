using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using NUnit.Framework;
using quizApp.Application.Handlers;
using quizApp.Application.Queries;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.UnitTest.Application
{
    [TestFixture]
    public class GetQuizByIdHandlerTest
    {
        private Mock<IRepositoryGeneric<Quiz>> _mock;

        [SetUp]
        public void Init()
        {
            _mock = new Mock<IRepositoryGeneric<Quiz>>();
            _mock.Setup(r => r.FindByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(new Quiz {_id = "228", Title = "legalize"});
            Quiz quiz = null;
            _mock.Setup(r => r.FindByIdAsync(It.Is<string>(s => s == string.Empty)))
                .ReturnsAsync(quiz);
        }

        [Test]
        public async Task NullResult()
        {
            var query = new GetQuizByIdQuery("");
            var handler = new GetQuizByIdHandler(_mock.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.IsNull(result);
        }

        [Test]
        public async Task ReturnQuiz()
        {
            var query = new GetQuizByIdQuery("1");
            var handler = new GetQuizByIdHandler(_mock.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.AreEqual(result.GetType(), typeof(Quiz));
        }
    }
}