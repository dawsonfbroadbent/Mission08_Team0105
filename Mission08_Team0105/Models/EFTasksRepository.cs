namespace Mission08_Team0105.Models;

public class EFTasksRepository : ITasksRepository
{
    private TasksContext _context;
    
    public EFTasksRepository(TasksContext temp)
    {
        _context = temp;
    }
    
    public List<Task> Tasks => _context.Tasks.ToList();
    
    public void AddTask(Task task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
    }
    
    public void DeleteTask(Task task)
    {
        _context.Tasks.Remove(task);
        _context.SaveChanges();
    }
}