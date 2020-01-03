using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using quizApp.Application.Commands;

namespace quizApp.Application.Handlers
{
    class CreateUserHandler: IRequestHandler<CreateUserCommand, bool>
    {
        public Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
