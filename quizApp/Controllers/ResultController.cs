using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quizApp.Application.Commands;
using quizApp.Application.Queries;
using quizApp.Domain.Models;

namespace quizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResultController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetResults()
        {
            var query = new GetAllResultsQuery();
            var result = await _mediator.Send(query);


            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetResultById(string id)
        {
            var query = new GetResultByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateResult(QuizResult quizResult)
        {
            var command = new CreateResultCommand(quizResult);
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteResult(string id)
        {
            var command = new DeleteResultCommand(id);
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateResult(QuizResult quizResult)
        {
            if (quizResult == null)
            {
                throw new NullReferenceException("ResultController.UpdateResult: NullReferenceException - quizResult is null " + DateTime.Now);
            }
            var command = new UpdateResultCommand(quizResult);
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
