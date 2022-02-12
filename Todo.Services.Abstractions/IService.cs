using Todo.Domain;

namespace Todo.Service.Abstractions
{
    public interface IService
    {
        List<Tasks> GetTasks();
        Tasks GetTaskById(int id);
        void AddTask(Tasks tasks);
        void EditTask(int idTask, Tasks tasks);
        void DeleteTask(int id);
    }
}
