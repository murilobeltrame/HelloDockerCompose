
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace api.Models
{
    public class TodoContext
    {
        private readonly IMongoDatabase _database = null;

        public IMongoCollection<Todo> Todos { 
            get {
                return _database.GetCollection<Todo>("Todo");
            } 
        }

        public TodoContext(IOptions<MongoSettings> settings){
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }
    }
}