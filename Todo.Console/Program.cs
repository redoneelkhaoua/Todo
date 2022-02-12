// See https://aka.ms/new-console-template for more information


using Microsoft.Extensions.DependencyInjection;
using Todo.DependencyInjection;
using Todo.Domain;
using Todo.Service.Abstractions;

var services = new ServiceCollection();

services.AddTodoList();



var provider = services.BuildServiceProvider();


var service = provider.GetService<IService>();


// dir li bghiti 
service.AddTask(new Tasks()
{
    Details = "ssss"
});