using System;
using System.Collections.Generic;
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
        public List<User> GetList()
        {
            return _collection.Find(user => true).ToList();
        }

        public List<User> GetList(Func<User, bool> predicate)
        {
            return _collection.Find(user => predicate.Invoke(user)).ToList();
        }

        public User FindById(string id)
        {
            return _collection.Find(user => user._id.ToString() == id).FirstOrDefault();
        }

        public void Create(User item)
        {
            _collection.InsertOne(item);
        }

        public void Remove(User item)
        {
            _collection.DeleteOne(user => user._id == item._id);
        }

        public void Update(User item)
        {
            _collection.ReplaceOne(user => user._id == item._id, item);
        }
    }
}