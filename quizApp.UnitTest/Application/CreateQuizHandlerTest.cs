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
    public class CreateQuizHandlerTest
    {
        private Mock<IRepositoryGeneric<Quiz>> _mock;

        [SetUp]
        public void Init()
        {
            _mock = new Mock<IRepositoryGeneric<Quiz>>();
            _mock.Setup(r => r.CreateAsync(It.Is<Quiz>(q => q._id != string.Empty || q._id != null)))
                .Throws<ArgumentException>();
            _mock.Setup(r => r.CreateAsync(It.Is<Quiz>(q => q._id == null || q._id == string.Empty)));
        }

        [Test]
        public void CreateQuizHandler_ResultNotNull()
        {
            var command = new CreateQuizCommand(new Quiz());
            var handler = new CreateQuizHandler(_mock.Object);

            var result = handler.Handle(command, CancellationToken.None);

            Assert.NotNull(result);
        }

        [Test]
        public async Task CreateQuizHandler_ResultFalse()
        {
            var command = new CreateQuizCommand(new Quiz{ _id = "1"});
            var handler = new CreateQuizHandler(_mock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.AreEqual(result, false);
        }
        
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public async Task CreateQuizHandler_ResultTrue(string value)
        {
            var command = new CreateQuizCommand(new Quiz { _id = value });
            var handler = new CreateQuizHandler(_mock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.AreEqual(result, true);
        }
    }
}