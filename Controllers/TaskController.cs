using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Models;  

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly TaskManagementDBContext _context;

    public TaskController(TaskManagementDBContext context)
    {
        _context = context;
    }

    // ✅ Get all tasks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskManagementSystem.Models.Task>>> GetTasks()
    {
        var tasks = await _context.Tasks.ToListAsync(); 
        return Ok(tasks);
    }

    // ✅ Get task by ID
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskManagementSystem.Models.Task>> GetTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    // ✅ Create a new task
    [HttpPost]
    public async Task<ActionResult<TaskManagementSystem.Models.Task>> CreateTask(TaskManagementSystem.Models.Task task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    // ✅ Update an existing task
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, TaskManagementSystem.Models.Task task)
    {
        if (id != task.Id)
        {
            return BadRequest();
        }

        _context.Entry(task).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // ✅ Delete a task
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
