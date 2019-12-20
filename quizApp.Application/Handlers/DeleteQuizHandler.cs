﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using quizApp.Application.Commands;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.Application.Handlers
{
    public class DeleteQuizHandler: IRequestHandler<DeleteQuizCommand, bool>
    {
        private QuizRepository _repository;

        public DeleteQuizHandler(IQuizDatabaseSettings settings)
        {
            _repository = new QuizRepository(settings);
        }
        public async Task<bool> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
        {
            try
            {   
                await _repository.RemoveAsync(request.Id);
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