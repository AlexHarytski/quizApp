using System;
using Moq;
using NUnit.Framework;
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
            _mock.Setup(r => r.CreateAsync(It.Is<Quiz>(q => q._id != string.Empty || q._id != null)))
                .Throws<ArgumentException>();
            _mock.Setup(r => r.CreateAsync(It.IsAny<Quiz>()));
        }
    }
}