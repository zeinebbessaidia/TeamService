using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TeamService.Models;

namespace TeamService.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly IMongoCollection<Team> _collection;
        private readonly DbConfiguration _settings;
        public TeamRepository(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<Team>(_settings.CollectionName);
        }

        public Task<List<Team>> GetAllAsync()
        {
            return _collection.Find(c => true).ToListAsync();
        }
        public Task<Team> GetByIdAsync(string id)
        {
            return _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Team> CreateAsync(Team Team)
        {
            await _collection.InsertOneAsync(Team).ConfigureAwait(false);
            return Team;
        }
        public Task UpdateAsync(string id, Team Team)
        {
            return _collection.ReplaceOneAsync(c => c.Id == id, Team);
        }
        public Task DeleteAsync(string id)
        {
            return _collection.DeleteOneAsync(c => c.Id == id);
        }
    }
}
