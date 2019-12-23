using System;
using System.Collections.Generic;
using MediatR;
using Moq;
using NUnit.Framework;
using quizApp.Application.Handlers;
using quizApp.Application.Queries;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.UnitTest.Application
{
    [TestFixture]
    public class GetQuizByIdHandlerTest
    {
        [Test]
        public void GetAllQuizzesWithPreicate_ShouldReturnList()
        {
            GetAllUsersQuery query = new GetAllUsersQuery();
            var mock = new Mock<QuizRepository>();
            mock.Setup(x => x.GetListAsync(It.IsAny<Func<Quiz, bool>>())).ReturnsAsync(new List<Quiz>());
            //IMediator _mediator = new Mediator(mock);
            


        }
    }
}