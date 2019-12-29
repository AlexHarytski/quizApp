using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using quizApp.Application.Queries;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.Application.Handlers
{
    public class GetResultByIdHandler: IRequestHandler<GetResultByIdQuery, QuizResult>
    {

        private IRepositoryGeneric<QuizResult> _repository;
        public GetResultByIdHandler(IRepositoryGeneric<QuizResult> repository)
        {
            _repository = repository;
        }
        public async Task<QuizResult> Handle(GetResultByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QuizResult result = await _repository.FindByIdAsync(request.Id);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }   
    }
}