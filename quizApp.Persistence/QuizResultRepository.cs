using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
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
        public async Task<List<QuizResult>>GetListAsync()
        {
            //qr is quizResult
            return (await _collection.FindAsync(qr => true)).ToList();
        }

        public async Task<List<QuizResult>> GetListAsync(Func<QuizResult, bool> predicate)
        {
            return (await _collection.FindAsync(qr => predicate.Invoke(qr))).ToList();
        }

        public async Task<QuizResult> FindByIdAsync(string id)
        {
            return (await _collection.FindAsync(qr => qr._id == id)).FirstOrDefault();
        }

        public async Task CreateAsync(QuizResult item)
        {
            await _collection.InsertOneAsync(item);
        }

        public async Task RemoveAsync(string id)
        {
            await _collection.DeleteOneAsync(qr => qr._id == ObjectId.Parse(id));
        }

        public async Task UpdateAsync(QuizResult item)
        {
            await _collection.ReplaceOneAsync(qr => qr._id == item._id, item);
        }
    }
}