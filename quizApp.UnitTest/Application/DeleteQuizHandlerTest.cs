using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using quizApp.Application.Commands;
using quizApp.Application.Handlers;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.UnitTest.Application
{
    public class DeleteQuizHandlerTest
    {
        private Mock<IRepositoryGeneric<Quiz>> _mock;

        [SetUp]
        public void Init()
        {
            _mock = new Mock<IRepositoryGeneric<Quiz>>();
            _mock.Setup(r => r.RemoveAsync(It.Is<string>(q => q == null || q == string.Empty)))
                .Throws<ArgumentException>();
            _mock.Setup(r => r.RemoveAsync(It.Is<string>(q => q.Length > 0)));
        }

        [Test]
        public async Task ResultNotNull()
        {
            var command = new DeleteQuizCommand("");
            var handler = new DeleteQuizHandler(_mock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.NotNull(result);
        }

        [Test]
        [TestCase("")]
        [TestCase( null)]
        public async Task ResultFalse(string id)
        {
            var command = new DeleteQuizCommand(id);
            var handler = new DeleteQuizHandler(_mock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.AreEqual(result, false);
        }

        [Test]
        public async Task ResultTrue()
        {
            var command = new DeleteQuizCommand("1");
            var handler = new DeleteQuizHandler(_mock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.AreEqual(result, true);
        }
    }
}