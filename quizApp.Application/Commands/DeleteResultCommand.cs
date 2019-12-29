using MediatR;

namespace quizApp.Application.Commands
{
    public class DeleteResultCommand: IRequest<bool>
    {
        public string Id { get; private set; }

        public DeleteResultCommand(string id)
        {
            Id = id;
        }
    }
}