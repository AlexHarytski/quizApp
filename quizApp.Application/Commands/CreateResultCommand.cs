using MediatR;
using quizApp.Domain.Models;

namespace quizApp.Application.Commands
{
    public class CreateResultCommand:IRequest<bool>
    {
        public QuizResult Result { get; private set; }

        public CreateResultCommand(QuizResult result)
        {
            Result = result;
        }
    }
}