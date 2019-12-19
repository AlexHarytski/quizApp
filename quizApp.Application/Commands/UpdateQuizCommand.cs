using MediatR;
using quizApp.Domain.Models;

namespace quizApp.Application.Commands
{
    public class UpdateQuizCommand: IRequest<bool>
    {
        public Quiz Quiz { get; set; }
    }
}