namespace TaskManager.Data
{
    using Microsoft.EntityFrameworkCore;
    using TaskManager.Models;

    public class AppDbContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}