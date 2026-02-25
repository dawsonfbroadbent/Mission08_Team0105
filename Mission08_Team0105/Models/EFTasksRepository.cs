using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0105.Models;

public class EFTasksRepository : ITasksRepository
{
    // Database context 
    private readonly TasksContext _context;

    public EFTasksRepository(TasksContext temp)
    {
        _context = temp;
    }

    // Returns all tasks.
    // Includes Category so views can access category name without extra queries.
    public List<Task> GetTasks()
        => _context.Tasks
            .Include(t => t.Category)
            .ToList();

    // Returns all categories.
    // Used to populate dropdowns in Create/Edit views.
    public List<Category> GetCategories()
        => _context.Categories.ToList();

    // Returns a single task by Id.
    // Used for Edit, Delete, and Details pages.
    public Task? GetTaskById(int id)
        => _context.Tasks
            .Include(t => t.Category)
            .FirstOrDefault(t => t.Id == id);

    // Adds a new task to the database.
    public void AddTask(Task task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
    }

    // Updates an existing task.
    public void UpdateTask(Task task)
    {
        var existing = _context.Tasks.Find(task.Id);
        if (existing == null) return;

        existing.Task1 = task.Task1;
        existing.DueDate = task.DueDate;
        existing.Quadrant = task.Quadrant;
        existing.CategoryId = task.CategoryId;
        existing.Completed = task.Completed;

        _context.SaveChanges();
    }

    // Deletes a task by Id.
    public void DeleteTaskById(int id)
    {
        var existing = _context.Tasks.Find(id);
        if (existing == null) return;

        _context.Tasks.Remove(existing);
        _context.SaveChanges();
    }
}