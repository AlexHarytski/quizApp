using System;
using System.Collections.Generic;
using MongoDB.Driver;
using quizApp.Domain.Models;

namespace quizApp.Persistence
{
    public class QuizRepository: IRepositoryGeneric<Quiz>
    {
        private readonly IMongoCollection<Quiz> _collection;

        public QuizRepository(IQuizDatabaseSettings dbSettings)
        {
            IMongoClient client = new MongoClient(dbSettings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(dbSettings.DatabaseName);
            _collection = database.GetCollection<Quiz>(dbSettings.QuizCollectionName);
        }
        public List<Quiz> GetList()
        {
            return _collection.Find(quiz => true).ToList();
        }

        public List<Quiz> GetList(Func<Quiz, bool> predicate)
        {
            return _collection.Find(quiz => predicate.Invoke(quiz)).ToList();
        }


        public Quiz FindById(string id)
        {
            return _collection.Find(quiz => quiz._id.ToString() == id).FirstOrDefault();
        }

        public void Create(Quiz item)
        {
            _collection.InsertOne(item);
        }

        public void Remove(Quiz item)
        {
            _collection.DeleteOne(quiz => quiz._id == item._id);
        }

        public void Update(Quiz item)
        {
            _collection.ReplaceOne(quiz => item._id == quiz._id, item);
        }
    }
}