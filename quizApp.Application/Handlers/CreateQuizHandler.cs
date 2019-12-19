using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using quizApp.Application.Commands;
using quizApp.Persistence;

namespace quizApp.Application.Handlers
{
    public class CreateQuizHandler: IRequestHandler<CreateQuizCommand, bool>
    {
        private QuizRepository _repository;

        public CreateQuizHandler(IQuizDatabaseSettings settings)
        {
            _repository = new QuizRepository(settings);
        }
        public async Task<bool> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.CreateAsync(request.Quiz);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}