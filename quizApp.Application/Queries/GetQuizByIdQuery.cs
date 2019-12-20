using MediatR;
using quizApp.Domain.Models;

namespace quizApp.Application.Queries
{
    public class GetQuizByIdQuery: IRequest<Quiz>
    {
        public GetQuizByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; private set; }
    }
}