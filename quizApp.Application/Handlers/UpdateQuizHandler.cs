﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using quizApp.Application.Commands;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.Application.Handlers
{
    public class UpdateQuizHandler: IRequestHandler<UpdateQuizCommand, bool>
    {
        private readonly IRepositoryGeneric<Quiz> _repository;
        public UpdateQuizHandler(IRepositoryGeneric<Quiz> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.UpdateAsync(request.Quiz);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}