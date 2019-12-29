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
    public class UpdateResultHandlerTest
    {
        private Mock<IRepositoryGeneric<QuizResult>> _mock;
        [SetUp]
        public void Init()
        {
            _mock = new Mock<IRepositoryGeneric<QuizResult>>();
            _mock.Setup(r => r.UpdateAsync(It.Is<QuizResult>(q => q == null)))
                .Throws<NullReferenceException>();
            _mock.Setup(r => r.UpdateAsync(It.Is<QuizResult>(q => q._id == null)))
                .Throws<NullReferenceException>();
            _mock.Setup(r => r.UpdateAsync(It.Is<QuizResult>(q => q._id != null)));
        }

        [Test]
        public async Task NullResultFalse()
        {
            var command = new UpdateResultCommand(null);
            var handler = new UpdateResultHandler(_mock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task NullId_False()
        {
            var command = new UpdateResultCommand(new QuizResult() {_id = null});
            var handler = new UpdateResultHandler(_mock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task HasId_True()
        {
            var command = new UpdateResultCommand(new QuizResult() { _id = "1" });
            var handler = new UpdateResultHandler(_mock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.IsTrue(result);
        }
    }
}