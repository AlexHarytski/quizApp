using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using quizApp.Application.Commands;
using quizApp.Application.Queries;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.Application.Handlers
{
    public class UpdateUserHandler:IRequestHandler<CreateUserCommand, bool>
    {
        private IRepositoryGeneric<User> _repository;
        public UpdateUserHandler(IRepositoryGeneric<User> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.UpdateAsync(request.User);
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