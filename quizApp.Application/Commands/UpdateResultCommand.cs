using MediatR;
using quizApp.Domain.Models;

namespace quizApp.Application.Commands
{
    public class UpdateResultCommand:IRequest<bool>
    {
        public QuizResult Result { get; private set; }

        public UpdateResultCommand(QuizResult result)
        {
            Result = result;
        }
    }
}