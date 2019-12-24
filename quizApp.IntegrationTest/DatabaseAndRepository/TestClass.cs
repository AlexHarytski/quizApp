using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using NUnit.Framework;
using quizApp.Domain.Models;


namespace quizApp.IntegrationTest.DatabaseAndRepository
{
    [TestFixture]
    public class TestClass
    {
        private IMongoDatabase db;
        [OneTimeSetUp]
        public void Init()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            try
            {
                client.DropDatabase("quizAppTestDatabase");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            db = client.GetDatabase("quizAppTestDatabase");
            db.CreateCollection("Quiz");
            db.CreateCollection("QuizResult");
            db.CreateCollection("User");
        }

        [Test]
        [Order(1)]
        public async Task CreateQuizzes()
        {
            var collection = db.GetCollection<Quiz>(nameof(Quiz));


            await collection.InsertManyAsync(new List<Quiz>
            {
                new Quiz
                {
                    QuizType = "music",
                    Title = "Kpop",
                    QuizQuestion = new List<QuizQuestion>
                    {
                        new QuizQuestion
                        {
                            Title = "qq",
                            Score = 10,
                            Question = "who say qq?",
                            QuizVariant = new List<QuestionVariant>
                            {
                                new QuestionVariant
                                {
                                    VariantText = "bla-bla",
                                    IsCorrect = true
                                }
                            }
                        },
                    }

                },
                new Quiz(),
                new Quiz()
            });
            var result = collection.CountDocuments(q => true);

            Assert.IsTrue(result > 0);
        }

        [Test]
        [Order(2)]
        public async Task Get3Quizzes()
        {
            var collection = db.GetCollection<Quiz>(nameof(Quiz));

            var result = (await collection.FindAsync(q => true)).ToList();

            Assert.AreEqual(result.Count, 3);
        }

        [Test]
        [Order(3)]
        public async Task UpdateFirstQuiz()
        {
            var collection = db.GetCollection<Quiz>(nameof(Quiz));
            var quiz = (await collection.FindAsync(q => true)).ToList().FirstOrDefault();
            quiz.Title = "be-be-be";

            collection.ReplaceOne(q => q._id == quiz._id, quiz);
            var result = (await collection.FindAsync(q => q._id == quiz._id)).FirstOrDefault();
            
            Assert.AreEqual(quiz.Title, result.Title);
        }

        [Test]
        [Order(4)]
        public async Task DeleteOne()
        {
            var collection = db.GetCollection<Quiz>(nameof(Quiz));

            await collection.DeleteOneAsync(q => true);
            var result = collection.CountDocuments(q => true);

            Assert.AreEqual(result, 2);
        }
    }
}