using MediatR;

namespace quizApp.Application.Commands
{
    public class DeleteQuizCommand: IRequest<bool>
    {
        public string Id { get; set; }
    }
}