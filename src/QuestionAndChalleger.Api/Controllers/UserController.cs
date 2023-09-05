using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestionAndChalleger.Domain.Entities;
using QuestionAndChalleger.Manager.Interfaces.Manager;

namespace QuestionAndChalleger.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _manager;
        public UserController(IUserManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _manager.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _manager.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User entity)
        {
            var entityInsert = await _manager.InsertAsync(entity);
            return CreatedAtAction(nameof(Get), new { id = entityInsert.Id }, entityInsert);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] User entity)
        {
            var entityUpdate = await _manager.UpdateAsync(entity);
            if (entityUpdate == null)
            {
                return NotFound();
            }
            return Ok(entityUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _manager.DeleteAsync(id);
            return NoContent();
        }
    }
}
