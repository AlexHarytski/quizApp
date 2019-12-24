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
        private readonly IRepositoryGeneric<Quiz> _repository;

        public GetQuizByIdHandler(IRepositoryGeneric<Quiz> repository)
        {
            _repository = repository;
        }

        public async Task<Quiz> Handle(GetQuizByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FindByIdAsync(request.Id);
        }
    }
}