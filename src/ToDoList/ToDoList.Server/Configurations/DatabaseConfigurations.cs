﻿using Microsoft.EntityFrameworkCore;
using ToDoList.Dal;

namespace ToDoList.Server.Configurations;

public static class DatabaseConfigurations
{
    public static void Configuration(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

        builder.Services.AddDbContext<MainContext>(options =>
            options.UseSqlServer(connectionString));
    }
}
