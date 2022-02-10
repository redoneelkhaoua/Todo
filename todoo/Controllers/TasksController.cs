using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoo.Models;
using todoo.Repository;
using todoo.Service;

namespace todoo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        IService service;
       
        private readonly ILogger<TasksController> _logger;

        public TasksController(ILogger<TasksController> logger)
        {
            _logger = logger;
            service=new TasksService( new TasksRepository(new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id=red;Password=redd;")));
        }

        [HttpGet]
        public List<Tasks> Get()
        {
             
            return service.Get();
        }
        [HttpGet("{id}")]
        public Tasks Get(int id)
        {
            return service.Get(id);
        }
        [HttpPost]
        public void Post(Tasks tasks)
        {
            service.Post(tasks);
        }
        [HttpPut]
        public void Put(Tasks task)
        {
            service.Put(task);

        }
        public void Delete(int id)
        {
            service.Delete(id);


        }
    }
}
