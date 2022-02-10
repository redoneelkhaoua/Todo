using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoo.Models;

namespace todoo.Repository
{
    public interface IRepository
    {
        List<Tasks> Get();
        Tasks Get(int id);
        void Post(Tasks tasks);
        void Put(Tasks tasks);
        void Delete(int id);
    }
}
