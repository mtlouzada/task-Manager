using Microsoft.AspNetCore.Mvc;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
       public IActionResult Get([FromServices] AppDbContext context)
            => Ok(context.Tasks.ToList());

        [HttpGet("/{id:int}")]
       public IActionResult GetById(
        [FromRoute] int id,
        [FromServices] AppDbContext context)
        {
            var task = context.Tasks.FirstOrDefault(x => x.Id == id);
             if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost("/")]
        public IActionResult Post(
        [FromBody] TaskModel task,
        [FromServices] AppDbContext context)
        {
            context.Tasks.Add(task);
            context.SaveChanges();

            return Created($"/{task.Id}", task);
        }

        [HttpPut("/{id:int}")]
        public IActionResult Put(
            [FromRoute] int id,
            [FromBody] TaskModel task,
            [FromServices] AppDbContext context)
        {
            var model = context.Tasks.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return NotFound();

            model.Title = task.Title;
            model.Done = task.Done;


            context.Tasks.Update(model);
            context.SaveChanges();

            return Ok(model);
        }

        [HttpDelete("/{id:int}")]
        public IActionResult Delete(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var model = context.Tasks.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return NotFound();
         
            context.Tasks.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }

    }
}