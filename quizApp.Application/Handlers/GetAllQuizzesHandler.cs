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
        private readonly QuizRepository _repository;

        public GetAllQuizzesHandler(IQuizDatabaseSettings settings)
        {
            _repository = new QuizRepository(settings);
        }

        public async Task<List<Quiz>> Handle(GetAllQuizzesQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetList();
        }
    }
}