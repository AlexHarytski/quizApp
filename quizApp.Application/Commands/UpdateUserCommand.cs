using MediatR;
using quizApp.Domain.Models;

namespace quizApp.Application.Commands
{
    public class UpdateUserCommand:IRequest<bool>
    {
        public UpdateUserCommand(User user)
        {
            User = user;
        }
        public User User { get; private set; }

    }
}