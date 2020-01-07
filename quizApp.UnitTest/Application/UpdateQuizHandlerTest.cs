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
    public class UpdateQuizHandlerTest
    {
        private Mock<IRepositoryGeneric<Quiz>> _mock;

        [SetUp]
        public void Init()
        {
            _mock = new Mock<IRepositoryGeneric<Quiz>>();
            _mock.Setup(r => r.UpdateAsync(It.Is<Quiz>(q => q._id == null || q._id == string.Empty)))
                .Throws<ArgumentException>();
            _mock.Setup(r => r.UpdateAsync(It.Is<Quiz>(q => q._id.Length > 0)));
        }

        [Test]
        public async Task IsTrue()
        {
            var command = new UpdateQuizCommand(new Quiz {_id = "1"});
            var handler  = new UpdateQuizHandler(_mock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public async Task IsFalse(string value)
        {
            var command = new UpdateQuizCommand(new Quiz { _id = value });
            var handler = new UpdateQuizHandler(_mock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.IsFalse(result);
        }

    }
}