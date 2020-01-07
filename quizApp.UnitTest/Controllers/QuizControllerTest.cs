using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using NUnit.Framework;
using quizApp.Application.Commands;
using quizApp.Application.Queries;
using quizApp.Controllers;
using quizApp.Domain.Models;

namespace quizApp.UnitTest.Controllers
{
    [TestFixture]
    public class QuizControllerTest
    {
        private Mock<IMediator> _mock;
        [SetUp]
        public void Init()
        {
            _mock = new Mock<IMediator>();
            _mock.Setup(x => x.Send(It.IsAny<GetQuizByIdQuery>(), CancellationToken.None))
                .ReturnsAsync(new Quiz());
            _mock.Setup(x => x.Send(It.IsAny<GetAllQuizzesQuery>(), CancellationToken.None))
                .ReturnsAsync(new List<Quiz>
                {
                    new Quiz
                    {
                        _id = "1",
                        Title = "horror"
                    },
                    new Quiz
                    {
                        _id = "2",
                        Title = "music"
                    }
                });
            _mock.Setup(x => x.Send(It.IsAny<CreateQuizCommand>(), CancellationToken.None))
                .ReturnsAsync(true);
            _mock.Setup(x => x.Send(It.IsAny<DeleteQuizCommand>(), CancellationToken.None))
                .ReturnsAsync(true);
            _mock.Setup(x => x.Send(It.IsAny<UpdateQuizCommand>(), CancellationToken.None))
                .ReturnsAsync(true);
            
        }

        [Test]
        public async Task GetQuizByIdTest_QuizNotNull()
        {
            var controller = new QuizController(_mock.Object);
            var res = await controller.GetQuizById(string.Empty);
            Assert.NotNull(res);
        }



        [Test]
        public async Task GetQuizzes_ListQuizzesNotNull()
        {
            var controller = new QuizController(_mock.Object);

            var res = await controller.GetQuizzes();

            Assert.NotNull(res);
        }

        [Test]
        public async Task DeleteQuiz_NotNull()
        {
            var controller = new QuizController(_mock.Object);

            var res = await controller.DeleteQuiz("");

            Assert.NotNull(res);
        }

        [Test]
        public async Task UpdateQuiz_NotNull()
        {
            var controller = new QuizController(_mock.Object);

            var res = await controller.UpdateQuiz(new Quiz());

            Assert.NotNull(res);
        }

        [Test]
        public async Task UpdateQuiz_IfNullThrowException()
        {
            var controller = new QuizController(_mock.Object);

            AsyncTestDelegate res = async () => await controller.UpdateQuiz(null);

            Assert.CatchAsync<NullReferenceException>(res);
        }

        [Test]
        public async Task DeleteQuiz_QuizShouldBeDeleted()
        {
            var controller = new QuizController(_mock.Object);

            var res = await controller.DeleteQuiz("1");

            _mock.Verify(x => x.Send(It.IsAny<DeleteQuizCommand>(), CancellationToken.None));
        }

    }
}