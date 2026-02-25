namespace Mission08_Team0105.Models;

public interface ITasksRepository
{
    // Lists
    List<Task> GetTasks();                 // includes Category
    List<Category> GetCategories();        // for dropdown

    // Single-record reads (Edit/Delete/Details)
    Task? GetTaskById(int id);

    // Writes
    void AddTask(Task task);
    void UpdateTask(Task task);
    void DeleteTaskById(int id);
}