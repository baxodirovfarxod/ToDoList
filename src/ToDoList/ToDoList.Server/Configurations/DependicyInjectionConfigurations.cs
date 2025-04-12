using ToDoList.Bll.Services;
using ToDoList.Bll.Validators;
using ToDoList.Repository.ToDoItemRepository;

namespace ToDoList.Server.Configurations;

public static class DependicyInjectionConfigurations
{
    public static void Configure(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
        builder.Services.AddScoped<IToDoItemService, ToDoItemService>();

        builder.Services.AddScoped<ToDoItemUpdateDtoValidator, ToDoItemUpdateDtoValidator>();
        builder.Services.AddScoped<ToDoItemCreateDtoValidator, ToDoItemCreateDtoValidator>();
    }
}
