using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using quizApp.Persistence;
using quizApp.Domain.Models;
using quizApp.Application.Commands;

namespace quizApp.UnitTest.Application
{
    [TestFixture]
    class CreateUserHandlerTest
    {
        private Mock<IRepositoryGeneric<User>> _mock;

        [SetUp]
        public void Init()
        {
            _mock = new Mock<IRepositoryGeneric<User>>();
            _mock.Setup(r => r.CreateAsync(It.Is<User>(q => q._id != string.Empty && q._id != null)))
                .Throws<ArgumentException>();
            _mock.Setup(r => r.CreateAsync(It.Is<User>(q => q._id == null || q._id == string.Empty)));
        }

        [Test]
        public void CreateQuizHandler_ResultNotNull()
        {
            var command = new CreateUserCommand(new User());
            var handler = new CreateUserHandler(_mock.Object);

            var result = handler.Handle(command, CancellationToken.None);

            Assert.NotNull(result);
        }

        [Test]
        public async Task CreateQuizHandler_ResultFalse()
        {
            var command = new CreateQuizCommand(new Quiz { _id = "1" });
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
