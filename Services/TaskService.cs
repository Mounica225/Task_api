using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; // Needed for async programming
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;

public class TaskService
{
    private readonly TaskManagementDBContext _context;

    public TaskService(TaskManagementDBContext context)
    {
        _context = context;
    }

    public async System.Threading.Tasks.Task<List<TaskManagementSystem.Models.Task>> GetAllTasksAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async System.Threading.Tasks.Task<TaskManagementSystem.Models.Task> GetTaskByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }
}
