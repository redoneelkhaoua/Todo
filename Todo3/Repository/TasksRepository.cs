using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Todo3.Models;

namespace Todo3.Repository
{
    public class TasksRepository : IRepository
    {
        OracleConnection _oracleConnection;

        public TasksRepository(OracleConnection oracleConnection)
        {
            _oracleConnection = oracleConnection;
        }

   

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tasks> Get()
        {
            OracleCommand oracleCommand = new OracleCommand("select * from tasks", _oracleConnection);
            OracleDataReader oracleDataReader = oracleCommand.ExecuteReader();
            List<Tasks> listTasks = new List<Tasks>();
            while (oracleDataReader.Read())
            {
                Tasks tasks = new Tasks();
                tasks.id = oracleDataReader.GetInt32(0);
                tasks.name = oracleDataReader.GetString(1);
                tasks.details = oracleDataReader.GetString(2);
                listTasks.Add(tasks);
            }
            _oracleConnection.Close();
            return listTasks;

        }

        public Tasks Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Post(Tasks tasks)
        {
            throw new NotImplementedException();
        }

        public void Put(Tasks tasks)
        {
            throw new NotImplementedException();
        }
    }
}