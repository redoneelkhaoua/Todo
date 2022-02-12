using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoo.Models;
using todoo.Repository;

namespace todoo.Service
{
    public class TasksService : IService
    {
        IRepository _repository;

        public TasksService(IRepository repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);

        }

        public List<Tasks> Get()
        {
            return _repository.Get();

        }

        public Tasks Get(int id)
        { if (id <= 0)
            {
                throw new Exception("erreur");
            }
            else
            {
                return _repository.Get(id);
            }
            
        }

        public void Post(Tasks tasks)
        {
            if (tasks == null)
            {
                throw new Exception("erreur");
            }
            else if( tasks.statue.ToLower() =="not yet" || tasks.statue.ToLower() == "done")
            {
                _repository.Post(tasks);


            }
            else
            {
                throw new Exception("erreur");

            }
        }

        public void Put(Tasks tasks)
        {
            if (tasks == null)
            {
                throw new Exception("erreur");
            }
            else if (tasks.statue.ToLower() == "not yet" || tasks.statue.ToLower() == "done")
            {
                _repository.Put(tasks);

            }
            else
            {
                throw new Exception("erreur");


            }
        }
    }
}
