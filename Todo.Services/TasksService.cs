using Todo.Domain;
using Todo.Repository.Abstractions;
using Todo.Service.Abstractions;

namespace Todo.Services;

public class TasksService : IService
{
    private readonly IRepository _repository;

    public TasksService(IRepository repository)
    {
        _repository = repository;
    }

    public void DeleteTask(int id)
    {
        _repository.Delete(id);
    }

    public List<Tasks> GetTasks()
    {
        return _repository.Get();
    }

    public Tasks GetTaskById(int id)
    {
        if (id <= 0)
            throw new Exception("erreur");
        return _repository.Get(id);
    }

    public void AddTask(Tasks tasks)
    {
        if (tasks == null)
            throw new Exception("erreur");
        if (tasks.Status.ToLower() == "not yet" || tasks.Status.ToLower() == "done")
            _repository.Post(tasks);
        else
            throw new Exception("erreur");
    }

    public void EditTask(int idTask, Tasks tasks)
    {
        // todo récuper id depuis la base le modifier et l'enregistrer
        if (tasks == null)
            throw new Exception("erreur");
        if (tasks.Status != "not yet" || tasks.Status != "done")
            throw new Exception("erreur");
        _repository.Post(tasks);
    }
}