using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using quizApp.Domain.Models;

namespace quizApp.Persistence
{
    public class QuizRepository: IRepositoryGeneric<Quiz>
    {
        private readonly IMongoCollection<Quiz> _collection;

        public QuizRepository(IMongoCollection<Quiz> collection)
        {
            _collection = collection;
        }
        public async Task<List<Quiz>> GetListAsync()
        {
            return (await _collection.FindAsync(quiz => true)).ToList();
        }

        public async Task<List<Quiz>> GetListAsync(Func<Quiz, bool> predicate)
        {
            return (await _collection.FindAsync(quiz => predicate.Invoke(quiz))).ToList();
        }


        public async Task<Quiz> FindByIdAsync(string id)
        {
            return (await _collection.FindAsync(quiz => quiz._id != id)).FirstOrDefault();
        }

        public async Task CreateAsync(Quiz item)
        {
            await _collection.InsertOneAsync(item);
        }

        public async Task RemoveAsync(string id)
        {
            await _collection.DeleteOneAsync(quiz => quiz._id == id);
        }

        public async Task UpdateAsync(Quiz item)
        {
            await _collection.ReplaceOneAsync(quiz => item._id == quiz._id, item);
        }
    }
}