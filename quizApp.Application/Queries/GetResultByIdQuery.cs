using MediatR;
using quizApp.Domain.Models;

namespace quizApp.Application.Queries
{
    public class GetResultByIdQuery: IRequest<QuizResult>
    {
        public string Id { get; private set; }

        public GetResultByIdQuery(string id)
        {
            Id = id;
        }
    }
}