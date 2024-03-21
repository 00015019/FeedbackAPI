
using Microsoft.AspNetCore.Mvc;
using Feedback_system.Repositories;
using Feedback_system.Model;

namespace Feedback_system.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeedbackCtrl : ControllerBase
    {
        private readonly IFeedbackRepository<Feedback> _repository;
        public FeedbackCtrl(IFeedbackRepository<Feedback> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Feedback>> GetAll() => await _repository.GetAllAsync();

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Feedback), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByID(int id)
        {
            var rFeadback = await _repository.GetByIDAsync(id);
            return rFeadback == null ? NotFound() : Ok(rFeadback);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Feedback feedback)
        {
            await _repository.AddAsync(feedback);
            //return Ok(feat);
            return CreatedAtAction(nameof(GetByID), new { feedback.Id }, feedback);

        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Feedback feedback)
        {
            await _repository.UpdateAsync(feedback);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
