using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using quizApp.Application.Commands;
using quizApp.Domain.Models;
using quizApp.Application.Queries;

namespace quizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuizController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetQuizzes()
        {
            var query = new GetAllQuizzesQuery();
            var result = await _mediator.Send(query);


            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuizById(string id)
        {
            var query = new GetQuizByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateQuiz(Quiz quiz)
        {
            var command = new CreateQuizCommand(quiz);
            var result =  await _mediator.Send(command);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteQuiz(string id)
        {
            var command = new DeleteQuizCommand(id);
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuiz(Quiz quiz)
        {
            if (quiz == null)
            {
                throw new NullReferenceException("QuizController.UpdateQuiz: NullReferenceException - quiz is null " + DateTime.Now);
            }
            var command  = new UpdateQuizCommand(quiz);
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}