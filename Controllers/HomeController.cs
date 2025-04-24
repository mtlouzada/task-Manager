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

        [HttpGet("/")]
        public TaskModel Post(
        [FromBody] TaskModel task,
        [FromServices] AppDbContext context)
        {
            context.Tasks.Add(task);
            context.SaveChanges();

            return task;
        }

        // public TaskModel Put(
        //     [FromBody] TaskModel task,
        //     [FromServices] AppDbContext context)
        // {
        //     context.Tasks.Update(task);
        //     context.SaveChanges();
        //     return task;
        // }

        // public void Delete(
        //     int id,
        //     [FromServices] AppDbContext context)
        // {
        //     var task = new TaskModel { Id = id };
        //     context.Tasks.Remove(task);
        //     context.SaveChanges();
        // }
        // [HttpGet("/tasks/{id}")]    
    }
}