using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using quizApp.Application.Queries;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.Application.Handlers
{
    public class GetUserByIdHandler: IRequestHandler<GetUserByIdQuery, User>
    {
        private IRepositoryGeneric<User> _repository;
        public GetUserByIdHandler(IRepositoryGeneric<User> repository)
        {
            _repository = repository;
        }
        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = (await _repository.GetListAsync(u => u._id == request.Id)).FirstOrDefault();
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