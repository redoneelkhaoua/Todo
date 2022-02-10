using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoo.Models;

namespace todoo.Repository
{
    public class TasksRepository :IRepository
    {
        OracleConnection _oracleConnection;

        public TasksRepository(OracleConnection oracleConnection)
        {
            _oracleConnection = oracleConnection;
        }

        public void Delete(int id)
        {
            _oracleConnection.Open();
            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter();
            OracleCommand oracleCommand = new OracleCommand("delete from tasks where id=" + id, _oracleConnection);
            oracleDataAdapter.DeleteCommand = new OracleCommand("delete from tasks where id=" + id, _oracleConnection);
            oracleDataAdapter.DeleteCommand.ExecuteNonQuery();
            _oracleConnection.Close();
        }

        public List<Tasks> Get()
        {
            _oracleConnection.Open();
            OracleCommand oracleCommand = new OracleCommand("select * from tasks", _oracleConnection);
            OracleDataReader oracleDataReader = oracleCommand.ExecuteReader();
            List<Tasks> listTasks = new List<Tasks>();
            while (oracleDataReader.Read())
            {
                Tasks tasks = new Tasks();
                tasks.id = oracleDataReader.GetInt32(0);
                tasks.statue = oracleDataReader.GetString(1);
                tasks.details = oracleDataReader.GetString(2);
                listTasks.Add(tasks);
            }
            _oracleConnection.Close();
            return listTasks;

        }

        public Tasks Get(int id)
        {
            _oracleConnection.Open();
            OracleCommand oracleCommand = new OracleCommand("select * from tasks where id="+id, _oracleConnection);
            OracleDataReader oracleDataReader = oracleCommand.ExecuteReader();
            Tasks tasks = new Tasks();
            if (oracleDataReader.Read())
            {
                tasks.id = oracleDataReader.GetInt32(0);
                tasks.statue = oracleDataReader.GetString(1);
                tasks.details = oracleDataReader.GetString(2);
                
            }
            _oracleConnection.Close();
            return tasks;
        }

        public void Post(Tasks tasks)
        {
            _oracleConnection.Open();
            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter();
            oracleDataAdapter.InsertCommand=new OracleCommand("insert into tasks values(" + tasks.id + ",'" + tasks.statue + "','" + tasks.details + "')", _oracleConnection);
            oracleDataAdapter.InsertCommand.ExecuteNonQuery();
            _oracleConnection.Close();

        }

        public void Put(Tasks tasks)
        {
            _oracleConnection.Open();
            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter();
            OracleCommand oracleCommand = new OracleCommand("update tasks set name='" + tasks.statue + "',details='" + tasks.details + "'where id=" + tasks.id, _oracleConnection);
            oracleDataAdapter.UpdateCommand = new OracleCommand("update tasks set name='" + tasks.statue + "',details='" + tasks.details + "'where id=" + tasks.id, _oracleConnection);
            oracleDataAdapter.UpdateCommand.ExecuteNonQuery();
            _oracleConnection.Close();
        }

       
    }
}
