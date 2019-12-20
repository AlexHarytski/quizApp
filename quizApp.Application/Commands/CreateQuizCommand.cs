using MediatR;
using quizApp.Domain.Models;

namespace quizApp.Application.Commands
{
    public class CreateQuizCommand : IRequest<bool>
    {
        public CreateQuizCommand(Quiz quiz)
        {
            Quiz = quiz;
        }

        public Quiz Quiz { get; private set; }
    }
}