using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;
using Todo.Repository.Abstractions;
using Todo.Repository.Oracle;
using Todo.Service.Abstractions;
using Todo.Services;

namespace Todo.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTodoList(this IServiceCollection services)
    {
        services.AddTransient<IRepository, TasksRepository>();
        // todo une connection par request => open à reception de request / fermeture une fois une reponse est donnée
        services.AddSingleton(new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id=red;Password=redd;"));
        services.AddTransient<IService, TasksService>();
        return services;
    }

    
}


