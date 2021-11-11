using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using TeamsChat.DataObjects.MongoDbModels;
using TeamsChat.MongoDbService.Settings;

namespace TeamsChat.WebApi.Services
{
    public class LogService
    {
        private readonly IMongoCollection<Logs> _books;

        public LogService(IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Logs>(settings.LogsCollectionName);
        }

        public List<Logs> Get() =>
            _books.Find(book => true).ToList();

        public Logs Get(string id) =>
            _books.Find<Logs>(book => book.Id == id).FirstOrDefault();

        public Logs Create(Logs book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string id, Logs bookIn) =>
            _books.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Logs bookIn) =>
            _books.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _books.DeleteOne(book => book.Id == id);
    }
}
