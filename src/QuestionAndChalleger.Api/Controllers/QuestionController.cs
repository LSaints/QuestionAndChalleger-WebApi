using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestionAndChalleger.Domain.Entities;
using QuestionAndChalleger.Manager.Interfaces.Manager;

namespace QuestionAndChalleger.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionManager _manager;
        public QuestionController(IQuestionManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _manager.GetAllAsync());
        }

        // GET api/<QuestionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _manager.GetByIdAsync(id));
        }

        // POST api/<QuestionController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Question entity)
        {
            var entityInsert = await _manager.InsertAsync(entity);
            return CreatedAtAction(nameof(Get), new { id = entityInsert.Id }, entityInsert);
        }

        // PUT api/<QuestionController>/5
        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Put([FromBody] Question entity)
        {
            var entityUpdate = await _manager.UpdateAsync(entity);
            if (entityUpdate == null)
            {
                return NotFound();
            }
            return Ok(entityUpdate);
        }

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            await _manager.DeleteAsync(id);
            return NoContent();
        }
    }
}
