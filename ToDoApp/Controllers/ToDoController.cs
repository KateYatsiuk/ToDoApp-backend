namespace ToDoTasks.WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ToDoTasks.BLL.Interfaces;
    using ToDoTasks.DAL.Entities;

    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        const string notFound = "Nothing found";
        const string notValid = "Not valid model";
        private readonly IToDoService _service;

        public ToDoController(IToDoService todoService)
        {
            _service = todoService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                var todoList = _service.GetAll();
                return Ok(todoList);
            }
            catch
            {
                return NotFound(new { error = notFound });
            }
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                ToDo obj = await _service.Get(u => u.Id == id);
                return Ok(obj);
            }
            catch
            {
                return NotFound(new { error = notFound });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ToDo obj)
        {
            if (ModelState.IsValid)
            {
                await _service.Create(obj);
                return Created(string.Empty, obj);
            }

            return BadRequest(new { error = notValid });
        }

        [HttpPut("put/{id}")]
        public async Task<IActionResult> Edit(int? id, [FromBody] ToDo obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { error = notValid });
            }

            try
            {
                ToDo newOne = await _service.Update(id, obj);
                return Ok(newOne);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception)
            {
                return BadRequest(new { error = notFound });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                await _service.Delete(id);
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception)
            {
                return NotFound(new { error = notFound });
            }
        }
    }
}