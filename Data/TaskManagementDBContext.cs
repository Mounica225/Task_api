using Microsoft.EntityFrameworkCore;

namespace TaskManagementSystem.Models
{
    public class TaskManagementDBContext : DbContext
    {
        public TaskManagementDBContext(DbContextOptions<TaskManagementDBContext> options)
            : base(options)
        {
        }

        // ✅ Use alias to avoid conflict with System.Threading.Tasks.Task
        public DbSet<TaskManagementSystem.Models.Task> Tasks { get; set; } = default!;
    }
}
