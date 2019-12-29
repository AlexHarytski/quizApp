using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using quizApp.Application.Commands;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.Application.Handlers
{
    public class UpdateResultHandler:IRequestHandler<UpdateResultCommand, bool>
    {
        private readonly IRepositoryGeneric<QuizResult> _repository;
        public UpdateResultHandler(IRepositoryGeneric<QuizResult> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(UpdateResultCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.UpdateAsync(request.Result);
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