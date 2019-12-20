using MediatR;
using quizApp.Domain.Models;

namespace quizApp.Application.Commands
{
    public class UpdateQuizCommand: IRequest<bool>
    {
        public UpdateQuizCommand(Quiz quiz)
        {
            Quiz = quiz;
        }

        public Quiz Quiz { get; private set; }
    }
}