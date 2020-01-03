using MediatR;
using quizApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace quizApp.Application.Commands
{
    public class CreateUserCommand: IRequest<bool>
    {
        public CreateUserCommand(User user)
        {
            User = user;
        }
        public User User { get; private set; }
    }
}
