using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamService.Models;
using TeamService.Services;

namespace TeamService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _TeamService;
        public TeamController(ITeamService TeamService)
        {
            _TeamService = TeamService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _TeamService.GetAllAsync().ConfigureAwait(false));
        }
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var Team = await _TeamService.GetByIdAsync(id).ConfigureAwait(false);
            if (Team == null)
            {
                return NotFound();
            }
            return Ok(Team);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Team Team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _TeamService.CreateAsync(Team).ConfigureAwait(false);
            return Ok(Team.Id);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Team TeamIn)
        {
            var Team = await _TeamService.GetByIdAsync(id).ConfigureAwait(false);
            if (Team == null)
            {
                return NotFound();
            }
            await _TeamService.UpdateAsync(id, TeamIn).ConfigureAwait(false);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var Team = await _TeamService.GetByIdAsync(id).ConfigureAwait(false);
            if (Team == null)
            {
                return NotFound();
            }
            await _TeamService.DeleteAsync(Team.Id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
