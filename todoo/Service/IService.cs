using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoo.Models;

namespace todoo.Service
{
    interface IService
    {
        List<Tasks> Get();
        Tasks Get(int id);
        void Post(Tasks tasks);
        void Put(Tasks tasks);
        void Delete(int id);
    }
}
