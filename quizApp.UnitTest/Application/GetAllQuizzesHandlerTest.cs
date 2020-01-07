using System;
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
    public class GetAllQuizzesHandlerTest
    {
        private Mock<IRepositoryGeneric<Quiz>> _mock;

        [SetUp]
        public void Init()
        {
            _mock = new Mock<IRepositoryGeneric<Quiz>>();
            _mock.Setup(r => r.GetListAsync())
                .ReturnsAsync(new List<Quiz>()
                {
                    new Quiz(),
                    new Quiz(),
                    new Quiz()
                });
        }

        [Test]
        public async Task ListQuizzesNotNull()
        {
            var query = new GetAllQuizzesQuery();
            var handler = new GetAllQuizzesHandler(_mock.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.IsNotNull(result);
        }        
        
        [Test]
        public async Task ListHas3Quizzes()
        {
            var query = new GetAllQuizzesQuery();
            var handler = new GetAllQuizzesHandler(_mock.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.AreEqual(result.Count, 3);
        }
    }
}