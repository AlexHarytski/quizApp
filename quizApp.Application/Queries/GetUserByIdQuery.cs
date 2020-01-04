using MediatR;
using quizApp.Domain.Models;

namespace quizApp.Application.Queries
{
    public class GetUserByIdQuery: IRequest<User>
    {
        public GetUserByIdQuery(string id)
        {
            Id = id;
        }
        public string Id { get; private set; }
    }
}