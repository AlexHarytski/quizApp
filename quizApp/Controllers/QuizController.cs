using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quizApp.Domain.Models;
using quizApp.Application.Services;
using quizApp.Application.Queries;

namespace quizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private QuizService quizService;
        private readonly IMediator _mediator;

        public QuizController(QuizService service, IMediator mediator)
        {
            quizService = service;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuizzes()
        {
            var query = new GetAllQuizzesQuery();
            var result = _mediator.Send(query);
            return Ok(result);
        }


        //if you want to check another repo
        //VVVVVVVVV
        //[HttpGet]
        //public List<Quiz> GetQuizzes()
        //{
        //    return quizService.GetQuizzes();
        //}

        //[HttpGet]
        //public List<QuizResult> GetResults()
        //{
        //    return quizService.GerResults();
        //}
    }
}