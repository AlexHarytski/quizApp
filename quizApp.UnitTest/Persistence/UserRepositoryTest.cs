using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using quizApp.Application.Handlers;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.UnitTest.Persistence
{
    [TestFixture]
    public class UserRepositoryTest
    {

        [Test]
        public void GetListAsyncWithPredicateTest()
        {
            var mock = new Mock<UserRepository>();
            mock.Setup(x => x.GetListAsync(It.IsAny<Func<User, bool>>())).ReturnsAsync(new List<User>());
            //GetAllUsersHandler handler = new GetAllUsersHandler();


        }
    }
}