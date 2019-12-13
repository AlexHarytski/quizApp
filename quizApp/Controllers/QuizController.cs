using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quizApp.Domain.Models;
using quizApp.Application.Services;

namespace quizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private QuizService quizService;

        public QuizController(QuizService service)
        {
            quizService = service;
        }

        [HttpGet]
        public List<User> GetUsers()
        {
            return quizService.GetUsers();
        }


        //if you want to check another repo
        //VVVVVVVVV
        //[HttpGet]
        //public List<Quiz> GetQuizzes()
        //{
        //    return quizService.GetQuizzes();
        //}

        //[HttpGet]
        //public List<QuizResult> GetResults()
        //{
        //    return quizService.GerResults();
        //}
    }
}