using MediatR;
using quizApp.Domain.Models;

namespace quizApp.Application.Queries
{
    public class GetQuizByIdQuery: IRequest<Quiz>
    {
        public string Id { get; set; }
    }
}