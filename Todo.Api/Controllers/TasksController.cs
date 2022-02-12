using Microsoft.AspNetCore.Mvc;
using Todo.Domain;
using Todo.Service.Abstractions;

namespace Todo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private readonly ILogger<TasksController> _logger;
    private readonly IService _service;

    public TasksController(
        IService service,
        ILogger<TasksController> logger)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public List<Tasks> GetTasks()
    {
        return _service.GetTasks();
    }

    [HttpGet("{id}")]
    public Tasks GetById(int id)
    {
        return _service.GetTaskById(id);
    }


    [HttpPost]
    public void AddTask(Tasks tasks)
    {
        _service.AddTask(tasks);
    }


    [HttpPut("{id}")]
    public void EditTask(int idTask, Tasks task)
    {
        _service.EditTask(idTask, task);
    }

    [HttpDelete("{id}")]
    public void DeleteTask(int id)
    {
        _service.DeleteTask(id);
    }
}