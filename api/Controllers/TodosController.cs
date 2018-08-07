using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _repository;

        public TodosController(ITodoRepository repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Todo>), 200)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Todo), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(string id)
        {
            var _item = await _repository.Get(id);
            if (_item == null) return NotFound();
            else return Ok(_item);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(typeof(Todo), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Todo todo)
        {
            if (todo == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            await _repository.Add(todo);
            return CreatedAtAction(nameof(Get), new {id = todo.Id}, todo);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(string id, [FromBody] Todo todo)
        {
            if (todo == null) return BadRequest();
            if (todo.Id != id) return BadRequest();
            var _exists = await _repository.Get(id) != null;
            if (!_exists) return NotFound();
            if (!ModelState.IsValid) return BadRequest();
            await _repository.Update(id, todo);
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(string id)
        {
            var _todo = await _repository.Get(id);
            if (_todo == null) return NotFound();
            await _repository.Delete(id);
            return NoContent();
        }
    }
}
