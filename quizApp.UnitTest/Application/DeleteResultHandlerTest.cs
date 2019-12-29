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
    [TestFixture]
    public class DeleteResultHandlerTest
    {

        private Mock<IRepositoryGeneric<QuizResult>> _mock;
        [SetUp]
        public void Init()
        {
            _mock = new Mock<IRepositoryGeneric<QuizResult>>();
            _mock.Setup(r => r.RemoveAsync(It.Is<string>(q => q == null || q == "")))
                .Throws<ArgumentException>();
            _mock.Setup(r => r.RemoveAsync(It.Is<string>(q => q != null)));
        }

        [Test]
        [TestCase(null)]
        public async Task InvalidId_False(string id)
        {
            var command = new DeleteResultCommand(id);
            var handler = new DeleteResultHandler(_mock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task IdNotEmpty()
        {
            var command = new DeleteResultCommand("1");
            var handler = new DeleteResultHandler(_mock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.IsTrue(result);
        }
    }
}