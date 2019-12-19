using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using quizApp.Domain.Models;

namespace quizApp.Persistence
{
    public class UserRepository: IRepositoryGeneric<User>
    {
        private readonly IMongoCollection<User> _collection;
        public UserRepository(IQuizDatabaseSettings dbSettings)
        {
            IMongoClient client = new MongoClient(dbSettings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(dbSettings.DatabaseName);

            _collection = database.GetCollection<User>(dbSettings.UserCollectionName);
        }
        public async Task<List<User>> GetListAsync()
        {
            var users = await _collection.FindAsync(user => true);
            var list = users.ToList();
            return list;
        }

        public async Task<List<User>> GetListAsync(Func<User, bool> predicate)
        {
            var users = await _collection.FindAsync(user => predicate.Invoke(user));
            var list = users.ToList();
            return list;
        }

        public async Task<User> FindByIdAsync(string id)
        {
            return (await _collection.FindAsync(user => user._id.ToString() == id)).FirstOrDefault();
        }

        public async Task CreateAsync(User item)
        {
            await _collection.InsertOneAsync(item);
        }

        public async Task RemoveAsync(string id)
        {
            await _collection.DeleteOneAsync(user => user._id.ToString() == id);
        }

        public async Task UpdateAsync(User item)
        { 
            await _collection.ReplaceOneAsync(user => user._id == item._id, item);
        }
    }
}