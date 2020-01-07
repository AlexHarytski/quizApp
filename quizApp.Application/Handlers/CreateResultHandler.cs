using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using quizApp.Application.Commands;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.Application.Handlers
{
    public class CreateResultHandler:IRequestHandler<CreateResultCommand, bool>
    {
        private readonly IRepositoryGeneric<QuizResult> _repository;
        public CreateResultHandler(IRepositoryGeneric<QuizResult> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(CreateResultCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Result._id != null)
                {
                    return false;
                }
                await _repository.CreateAsync(request.Result);
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