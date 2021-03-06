using Oracle.ManagedDataAccess.Client;
using Todo.Domain;
using Todo.Repository.Abstractions;

namespace Todo.Repository.Oracle;

public class TasksRepository : IRepository
{
    private readonly OracleConnection _oracleConnection;

    public TasksRepository(OracleConnection oracleConnection)
    {
        _oracleConnection = oracleConnection;
    }

    public void Delete(int id)
    {
        _oracleConnection.Open();
        var oracleDataAdapter = new OracleDataAdapter();
        oracleDataAdapter.DeleteCommand = new OracleCommand("delete from tasks where id=" + id, _oracleConnection);
        oracleDataAdapter.DeleteCommand.ExecuteNonQuery();
        _oracleConnection.Close();
    }

    public List<Tasks> Get()
    {
        _oracleConnection.Open();
        var oracleCommand = new OracleCommand("select * from tasks", _oracleConnection);
        var oracleDataReader = oracleCommand.ExecuteReader();
        var listTasks = new List<Tasks>();
        while (oracleDataReader.Read())
        {
            var tasks = new Tasks();
            tasks.Id = oracleDataReader.GetInt32(0);
            tasks.Status = oracleDataReader.GetString(1);
            tasks.Details = oracleDataReader.GetString(2);
            listTasks.Add(tasks);
        }

        _oracleConnection.Close();
        return listTasks;
    }

    public Tasks Get(int id)
    {
        _oracleConnection.Open();
        var oracleCommand = new OracleCommand("select * from tasks where id=" + id, _oracleConnection);
        var oracleDataReader = oracleCommand.ExecuteReader();
        var tasks = new Tasks();
        if (oracleDataReader.Read())
        {
            tasks.Id = oracleDataReader.GetInt32(0);
            tasks.Status = oracleDataReader.GetString(1);
            tasks.Details = oracleDataReader.GetString(2);
        }

        _oracleConnection.Close();
        return tasks;
    }

    public void Post(Tasks tasks)
    {
        _oracleConnection.Open();
        var oracleDataAdapter = new OracleDataAdapter();
        oracleDataAdapter.InsertCommand = new OracleCommand(
            "insert into tasks values(" + tasks.Id + ",'" + tasks.Status + "','" + tasks.Details + "')",
            _oracleConnection);
        oracleDataAdapter.InsertCommand.ExecuteNonQuery();
        _oracleConnection.Close();
    }

    public void Put(Tasks tasks)
    {
        _oracleConnection.Open();
        var oracleDataAdapter = new OracleDataAdapter();
        var oracleCommand =
            new OracleCommand(
                "update tasks set name='" + tasks.Status + "',details='" + tasks.Details + "'where id=" + tasks.Id,
                _oracleConnection);
        oracleDataAdapter.UpdateCommand = new OracleCommand(
            "update tasks set name='" + tasks.Details + "',details='" + tasks.Details + "'where id=" + tasks.Id,
            _oracleConnection);
        oracleDataAdapter.UpdateCommand.ExecuteNonQuery();
        _oracleConnection.Close();
    }
}