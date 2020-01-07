using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using quizApp.Application.Queries;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.Application.Handlers
{
    public class GetAllResultsHandler: IRequestHandler<GetAllResultsQuery, List<QuizResult>>
    {
        private readonly IRepositoryGeneric<QuizResult> _repository;
        public GetAllResultsHandler(IRepositoryGeneric<QuizResult> repository)
        {
            _repository = repository;
        }
        public async Task<List<QuizResult>> Handle(GetAllResultsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allResults = await _repository.GetListAsync();
                return allResults;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<QuizResult>();
            }
        }
    }
}