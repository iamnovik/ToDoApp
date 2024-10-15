using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.BLL.Services.Implementations;
using ToDo.BLL.Services.Interfaces;


namespace ToDo.BLL.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());  
        services.AddScoped<IToDoService, ToDoService>();

        return services;
    }
}