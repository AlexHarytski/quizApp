using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using quizApp.Application.Queries;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.Application.Handlers
{
    public class GetAllQuizzesHandler: IRequestHandler<GetAllQuizzesQuery, List<Quiz>>
    {
        private readonly IRepositoryGeneric<Quiz> _repository;

        public GetAllQuizzesHandler(IRepositoryGeneric<Quiz> repository)
        {
            _repository = repository;
        }

        public async Task<List<Quiz>> Handle(GetAllQuizzesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetListAsync();
        }
    }
}