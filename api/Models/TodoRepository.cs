using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace api.Models
{
    public interface ITodoRepository
    {
        Task<Todo> Get(string id);
        Task<IEnumerable<Todo>> GetAll();
        Task Add(Todo todo);
        Task<bool> Delete(string id);
        Task<bool> Update(string id, Todo todo);
    }

    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(IOptions<MongoSettings> settings)
        {
            _context = new TodoContext(settings);
        }

        public async Task Add(Todo todo)
        {
            await _context.Todos.InsertOneAsync(todo);
        }

        public async Task<bool> Delete(string id)
        {
            var _actionResult = await _context.Todos.DeleteOneAsync(Builders<Todo>.Filter.Eq("Id", id));
            return _actionResult.IsAcknowledged && _actionResult.DeletedCount > 0;
        }

        public async Task<Todo> Get(string id) {
            var _internalId = GetInternalId(id);
            return await _context.Todos.Find(_ => _.Id == id || _.InternalId == _internalId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
            return await _context.Todos.Find(_ => true).ToListAsync();
        }

        public async Task<bool> Update(string id, Todo todo)
        {
            var _filter = Builders<Todo>.Filter.Eq(s => "Id", id);
            var _update = Builders<Todo>.Update
                .Set(s => s.Description, todo.Description)
                .Set(s => s.Done, todo.Done)
                .CurrentDate(s => DateTime.Now);
            var _actionResult = await _context.Todos.UpdateOneAsync(_filter, _update);
            return _actionResult.IsAcknowledged && _actionResult.ModifiedCount > 0;
        }

        private ObjectId GetInternalId(string id) {
            ObjectId _internalId;
            if (!ObjectId.TryParse(id, out _internalId)) _internalId = ObjectId.Empty;
            return _internalId;
        }
    }
}