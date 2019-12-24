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
    public class GetAllUsersHandlerTest
    {
        private Mock<IRepositoryGeneric<User>> _mock;

        [SetUp]
        public void Init()
        {
            _mock = new Mock<IRepositoryGeneric<User>>();
            _mock.Setup(r => r.GetListAsync())
                .ReturnsAsync(
                    new List<User>
                    {
                        new User{ Email = "alex@mail.ru"},
                        new User{ Email = "doigrales@maeel.ru"},
                        new User{ Email = "pigor@mairu.ru", }
                    }
                );
        }

        [Test]
        public async Task NotNull()
        {
            var query = new GetAllUsersQuery();
            var handler = new GetAllUsersHandler(_mock.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
        }

        [Test]
        public async Task HasResult()
        {
            var query = new GetAllUsersQuery();
            var handler = new GetAllUsersHandler(_mock.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.AreEqual(result.Count, 3);
        }


    }
}