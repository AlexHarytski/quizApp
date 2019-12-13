using System;
using System.Collections.Generic;
using MongoDB.Driver;
using quizApp.Domain.Models;

namespace quizApp.Persistence
{
    public class QuizResultRepository: IRepositoryGeneric<QuizResult>
    {
        private readonly IMongoCollection<QuizResult> _collection;

        public QuizResultRepository(IQuizDatabaseSettings dbSettings)
        {
            IMongoClient client = new MongoClient(dbSettings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(dbSettings.DatabaseName);

            _collection = database.GetCollection<QuizResult>(dbSettings.QuizResultCollectionName);
        }
        public List<QuizResult> GetList()
        {
            //qr is quizResult
            return _collection.Find(qr => true).ToList();
        }

        public List<QuizResult> GetList(Func<QuizResult, bool> predicate)
        {
            return _collection.Find(qr => predicate.Invoke(qr)).ToList();
        }

        public QuizResult FindById(string id)
        {
            return _collection.Find(qr => qr._id.ToString() == id).FirstOrDefault();
        }

        public void Create(QuizResult item)
        {
            _collection.InsertOne(item);
        }

        public void Remove(QuizResult item)
        {
            _collection.DeleteOne(qr => qr._id == item._id);
        }

        public void Update(QuizResult item)
        {
            _collection.ReplaceOne(qr => qr._id == item._id, item);
        }
    }
}