using MediatR;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using quizApp.Application.Commands;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.Application.Handlers
{
    public class CreateUserHandler: IRequestHandler<CreateUserCommand, bool>
    {
        private IRepositoryGeneric<User> _repository;
        public CreateUserHandler(IRepositoryGeneric<User> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.CreateAsync(request.User);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
