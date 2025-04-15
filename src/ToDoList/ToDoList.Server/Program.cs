
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Bll.Services;
using ToDoList.Server.Configurations;

namespace ToDoList.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Configure();
            builder.Configuration();


            // Register strategies
            builder.Services.AddTransient<GetSummEvenNumbersWithFor>();
            builder.Services.AddTransient<GetSummEvenNumbersWithForeach>();
            builder.Services.AddTransient<GetSummEvenNumbersWithLinq>();
     
            // Register strategy resolver and context
            builder.Services.AddSingleton<EvenSumStrategyResolver>();
            builder.Services.AddScoped<EvenSumContext>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
