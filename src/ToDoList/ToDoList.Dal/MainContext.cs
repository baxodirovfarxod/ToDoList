using Microsoft.EntityFrameworkCore;
using ToDoList.Dal.Entity;

namespace ToDoList.Dal;

public class MainContext : DbContext
{
    public DbSet<ToDoItem> ToDoItems { get; set; }
    public MainContext(DbContextOptions<MainContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
