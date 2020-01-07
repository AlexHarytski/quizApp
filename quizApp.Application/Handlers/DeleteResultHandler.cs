using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using quizApp.Application.Commands;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.Application.Handlers
{
    public class DeleteResultHandler: IRequestHandler<DeleteResultCommand, bool>
    {
        private readonly IRepositoryGeneric<QuizResult> _repository;

        public DeleteResultHandler(IRepositoryGeneric<QuizResult> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteResultCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.RemoveAsync(request.Id);
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