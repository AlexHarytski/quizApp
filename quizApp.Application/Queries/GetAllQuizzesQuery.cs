using System.Collections.Generic;
using MediatR;
using quizApp.Domain.Models;

namespace quizApp.Application.Queries
{
    public class GetAllQuizzesQuery: IRequest<List<Quiz>>
    {
        
    }
}