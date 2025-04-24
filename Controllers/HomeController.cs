using Microsoft.AspNetCore.Mvc;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
       public List<TaskModel> Get([FromServices] AppDbContext context)
        {
            return context.Tasks.ToList();
        }

        [HttpGet("/{id:int}")]
       public TaskModel GetById(
        [FromRoute] int id,
        [FromServices] AppDbContext context)
        {
            return context.Tasks.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost("/task")]
        public TaskModel Post(
        [FromBody] TaskModel task,
        [FromServices] AppDbContext context)
        {
            context.Tasks.Add(task);
            context.SaveChanges();

            return task;
        }

        [HttpPut("/{id:int}")]
        public TaskModel Put(
            [FromRoute] int id,
            [FromBody] TaskModel task,
            [FromServices] AppDbContext context)
        {
            var model = context.Tasks.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return task;

            model.Title = task.Title;
            model.Done = task.Done;


            context.Tasks.Update(model);
            context.SaveChanges();

            return model;
        }

        [HttpDelete("/{id:int}")]
        public TaskModel Delete(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var model = context.Tasks.FirstOrDefault(x => x.Id == id);
         
            context.Tasks.Remove(model);
            context.SaveChanges();
            return model;
        }

    }
}