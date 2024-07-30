using System.Collections.Generic;
using System.Threading.Tasks;
using TeamService.Models;

namespace TeamService.Services
{
    public interface ITeamService
    {
        Task<List<Team>> GetAllAsync();
        Task<Team> GetByIdAsync(string id);
        Task<Team> CreateAsync(Team Team);
        Task UpdateAsync(string id, Team Team);
        Task DeleteAsync(string id);
    }
}
