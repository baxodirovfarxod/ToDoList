using ToDoList.Bll.Services;
using ToDoList.Repository.ToDoItemRepository;

namespace ToDoList.Server.Configurations;

public static class DependicyInjectionConfigurations
{
    public static void Configure(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
        builder.Services.AddScoped<IToDoItemService, ToDoItemService>();
    }
}
