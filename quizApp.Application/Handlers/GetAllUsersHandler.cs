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
        private readonly UserRepository _repository;

        //public GetAllUsersHandler(IMongoDatabase db, IQuizDatabaseSettings settings)
        public GetAllUsersHandler(IMongoCollection<User> userCollection)
        {
            _repository = new UserRepository(userCollection);
        }

        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetListAsync();
            return list;
        }
    }
}