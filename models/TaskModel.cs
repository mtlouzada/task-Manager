namespace TaskManager.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public bool Done { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}