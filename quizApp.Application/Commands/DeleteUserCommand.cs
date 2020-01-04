using MediatR;

namespace quizApp.Application.Commands
{
    public class DeleteUserCommand:IRequest<bool>
    {
        public DeleteUserCommand(string id)
        {
            Id = id;
        }
        public string Id { get; private set; }
    }
}