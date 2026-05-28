public interface ITaskService
{
    List<TaskModel> GetAll();
    void Add(TaskModel task);
    void Delete(TaskModel task);
}