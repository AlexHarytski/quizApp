using MediatR;

namespace quizApp.Application.Commands
{
    public class DeleteQuizCommand: IRequest<bool>
    {
        public DeleteQuizCommand(string id)
        {
            Id = id;
        }

        public string Id { get; private set; }
    }
}