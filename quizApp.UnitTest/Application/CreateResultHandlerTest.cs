using System;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using Moq;
using NUnit.Framework;
using quizApp.Application.Commands;
using quizApp.Application.Handlers;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.UnitTest.Application
{
    [TestFixture]
    public class CreateResultHandlerTest
    {
        private Mock<IRepositoryGeneric<QuizResult>> _mock;
        [SetUp]
        public void Init()
        {
            _mock = new Mock<IRepositoryGeneric<QuizResult>>();
            _mock.Setup(r => r.CreateAsync(It.Is<QuizResult>(q => q == null)))
                .Throws<NullReferenceException>();
            _mock.Setup(r => r.CreateAsync(It.Is<QuizResult>(q => q != null)));
            _mock.Setup(r => r.CreateAsync(It.Is<QuizResult>(q => q._id != null && q._id != string.Empty)))
                .Throws<Exception>();
            ObjectId tmpId;
            _mock.Setup(r => r.CreateAsync(It.Is<QuizResult>(q => ObjectId.TryParse(q._id, out tmpId))))
                .Throws<Exception>();
        }

        [Test]
        public async Task IfQuizNull_False()
        {
            var command = new CreateResultCommand(null);
            var handler = new CreateResultHandler(_mock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public async Task ResultIdNullOrEmpty_True(string value)
        {
            var command = new CreateResultCommand(new QuizResult{ _id = value} );
            var handler = new CreateResultHandler(_mock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("1")]
        [TestCase("some1Text")]
        [TestCase("5e08f0e631332ca005a642a5")]
        public async Task IfIdHasValue_False(string value)
        {
            var command = new CreateResultCommand(new QuizResult { _id = value });
            var handler = new CreateResultHandler(_mock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.IsFalse(result);
        }
    }
}