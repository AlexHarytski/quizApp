using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Driver;
using quizApp.Application.Commands;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.Application.Handlers
{
    public class CreateQuizHandler: IRequestHandler<CreateQuizCommand, bool>
    {
        private readonly IRepositoryGeneric<Quiz> _repository;

        public CreateQuizHandler(IRepositoryGeneric<Quiz> repository)
        {
            _repository = repository;
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