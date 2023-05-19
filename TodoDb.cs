using Microsoft.EntityFrameworkCore;
using TodoAPI;

public class TodoDb : DbContext
{
    public DbSet<Todo> Todos { get; set; }
    public TodoDb(DbContextOptions<TodoDb> options) : base(options) { }

}

