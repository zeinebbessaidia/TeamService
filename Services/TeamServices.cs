using System.Collections.Generic;
using System.Threading.Tasks;
using TeamService.Models;
using TeamService.Repository;

namespace TeamService.Services
{
    public class TeamServices : ITeamService
    {
        private readonly ITeamRepository _TeamRepository;

        public TeamServices(ITeamRepository TeamRepository)
        {
            _TeamRepository = TeamRepository;
        }

        public Task<List<Team>> GetAllAsync()
        {
            return _TeamRepository.GetAllAsync();
        }

        public Task<Team> GetByIdAsync(string id)
        {
            return _TeamRepository.GetByIdAsync(id);
        }

        public Task<Team> CreateAsync(Team Team)
        {
            return _TeamRepository.CreateAsync(Team);
        }

        public Task UpdateAsync(string id, Team Team)
        {
            return _TeamRepository.UpdateAsync(id, Team);
        }

        public Task DeleteAsync(string id)
        {
            return _TeamRepository.DeleteAsync(id);
        }
    }
}
