using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using quizApp.Application.Queries;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.Application.Handlers
{
    public class GetAllUsersHandler: IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private UserRepository _repository;

        public GetAllUsersHandler(IQuizDatabaseSettings settings)
        {
            _repository = new UserRepository(settings);
        }

        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetListAsync();
            return list;
        }
    }
}