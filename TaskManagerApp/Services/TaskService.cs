public class TaskService : ITaskService
{
    public List<TaskModel> GetAll()
    {
        using var db = DBContextFactory.Create();
        return db.Tasks.ToList();
    }

    public void Add(TaskModel task)
    {
        using var db = DBContextFactory.Create();
        db.Tasks.Add(task);
        db.SaveChanges();
    }

    public void Delete(TaskModel task)
    {
        using var db = DBContextFactory.Create();
        db.Tasks.Remove(task);
        db.SaveChanges();
    }
}