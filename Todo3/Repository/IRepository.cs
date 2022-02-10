using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo3.Models;

namespace Todo3.Repository
{
    interface IRepository
    {

         List<Tasks> Get();
        Tasks Get(int id);
        void Post(Tasks tasks);
        void Put(Tasks tasks);
        void Delete(int id);
    }
}
