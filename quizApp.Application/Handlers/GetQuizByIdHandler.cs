using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using quizApp.Application.Queries;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.Application.Handlers
{
    public class GetQuizByIdHandler : IRequestHandler<GetQuizByIdQuery, Quiz>
    {
        private readonly QuizRepository _repository;

        public GetQuizByIdHandler(IQuizDatabaseSettings settings)
        {
            _repository = new QuizRepository(settings);
        }

        public async Task<Quiz> Handle(GetQuizByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FindByIdAsync(request.Id);
        }
    }
}