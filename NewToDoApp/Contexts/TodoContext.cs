using Microsoft.EntityFrameworkCore;
namespace NewToDoApp.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }
    public DbSet<TodoItem> TodoItems { get; set; } = null!;

    public DbSet<Person> Persons { get; set; }
}