using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Driver;
using quizApp.Application.Queries;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.Application.Handlers
{
    public class GetAllUsersHandler: IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IRepositoryGeneric<User> _repository;

        //public GetAllUsersHandler(IMongoDatabase db, IQuizDatabaseSettings settings)
        public GetAllUsersHandler(IRepositoryGeneric<User> repository)
        {
            _repository = repository;
        }

        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetListAsync();
            return list;
        }
    }
}