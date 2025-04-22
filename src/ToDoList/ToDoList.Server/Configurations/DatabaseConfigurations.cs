using Microsoft.EntityFrameworkCore;
using ToDoList.Bll.ProFile;
using ToDoList.Dal;
using ToDoList.Repository.Settings;

namespace ToDoList.Server.Configurations;

public static class DatabaseConfigurations
{
    public static void Configuration(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

        var sqlDBConeectionString = new SqlDBConeectionString(connectionString);

        builder.Services.AddSingleton<SqlDBConeectionString>(sqlDBConeectionString);
        builder.Services.AddDbContext<MainContext>(options =>
          options.UseSqlServer(connectionString));


        builder.Services.AddAutoMapper(typeof(MappingProFile));
    }
}
