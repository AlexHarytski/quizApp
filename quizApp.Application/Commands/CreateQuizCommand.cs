﻿using MediatR;
using quizApp.Domain.Models;

namespace quizApp.Application.Commands
{
    public class CreateQuizCommand : IRequest<bool>
    {
        public Quiz Quiz { get; set; }
    }
}