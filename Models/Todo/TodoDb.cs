using Microsoft.EntityFrameworkCore;
using TodoAPI;

//Contexto do banco de dados
public class TodoDb : DbContext
{
    public DbSet<Todo> Todos { get; set; }
    public TodoDb(DbContextOptions<TodoDb> options) : base(options) { }

}

