using Todo.Domain;

namespace Todo.Repository.Abstractions;

public interface IRepository
{
    List<Tasks> Get();
    Tasks Get(int id);
    void Post(Tasks tasks);
    void Put(Tasks tasks);
    void Delete(int id);
}