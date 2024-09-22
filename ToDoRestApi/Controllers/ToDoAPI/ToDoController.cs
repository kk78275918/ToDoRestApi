using Microsoft.AspNetCore.Mvc;
using ToDoRestApi.Model;
using ToDoRestApi.ToDoService;

namespace ToDoRestApi.Controllers.ToDoAPI
{
	
	[Route("api/[controller]")]
	[ApiController]
	public class ToDoController : ControllerBase
	{
		private readonly ToDoServices _toDoService;

		public ToDoController(ToDoServices toDoService)
		{
			_toDoService = toDoService;
		}

		[HttpGet]
		public IActionResult GetAll(int pageIndex = 1, int pageSize = 10)
		{
			var todos = _toDoService.GetAll(pageIndex, pageSize);
			return Ok(todos);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var todo = _toDoService.GetById(id);
			if (todo == null) return NotFound();
			return Ok(todo);
		}

		[HttpPost]
		public IActionResult Add(ToDoItem todo)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			_toDoService.Add(todo);
			return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, ToDoItem todo)
		{
			if (id != todo.Id || !ModelState.IsValid)
			{
				return BadRequest();
			}
			_toDoService.Update(todo);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_toDoService.Delete(id);
			return NoContent();
		}
	}
}
