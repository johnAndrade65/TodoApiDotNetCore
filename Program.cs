using TodoAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Adição do TodoDb(Contexto do database) a injeção de dependencia para usar no database do SQL Server
builder.Services.AddDbContext<TodoDb>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

//URL padrão que se repetia em todas as requisições salva como valor de variavel para ser usada nas requisições
RouteGroupBuilder todoItemsUrl = app.MapGroup("/itens");

//Endpoints
todoItemsUrl.MapGet("/", GetAll);
todoItemsUrl.MapGet("/complete", GetComplete);
todoItemsUrl.MapGet("/{id}", GetById);
todoItemsUrl.MapPost("/", CreateItem);
todoItemsUrl.MapPut("/{id}", UpdateItem);
todoItemsUrl.MapDelete("/{id}", DeleteTodo);

//Método para rodar o app(API)
app.Run();

//Método de requisição GET All(Obter todos valores)
static async Task<IResult> GetAll(TodoDb db)
{
    return TypedResults.Ok(await db.Todos.Select(x => new TodoItemDTO(x)).ToArrayAsync());
}

//Método de requisição GET Complete(Obter apens valores onde "complete" for true)
static async Task<IResult> GetComplete(TodoDb db)
{
    return TypedResults.Ok(
        await db.Todos.Where(t => t.IsComplete).Select(x => new TodoItemDTO(x)).ToListAsync()
    );
}

//Método de requisição GET(Obter único valor via ID)
static async Task<IResult> GetById(int id, TodoDb db)
{
    return await db.Todos.FindAsync(id) is Todo todo
        ? TypedResults.Ok(new TodoItemDTO(todo))
        : TypedResults.NotFound();
}

//Método de requisição POST(Criar novos dados)
static async Task<IResult> CreateItem(TodoItemDTO todoItemDTO, TodoDb db)
{
    var todoItem = new Todo { IsComplete = todoItemDTO.IsComplete, Name = todoItemDTO.Name, Message = todoItemDTO.Message };

    db.Todos.Add(todoItem);
    await db.SaveChangesAsync();

    todoItemDTO = new TodoItemDTO(todoItem);

    return TypedResults.Created($"/todoitems/{todoItem.Id}", todoItemDTO);
}

//Método de requisição UPDATE(Atualizar dados existentes de acordo com a ID inserida)
static async Task<IResult> UpdateItem(int id, TodoItemDTO todoItemDTO, TodoDb db)
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null)
        return TypedResults.NotFound();

    todo.Name = todoItemDTO.Name;
    todo.IsComplete = todoItemDTO.IsComplete;

    await db.SaveChangesAsync();

    return TypedResults.NoContent();
}

//Método de requisição DELETE(Deletar dados de acordo com a ID inserida)
static async Task<IResult> DeleteTodo(int id, TodoDb db)
{
    if (await db.Todos.FindAsync(id) is Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();

        TodoItemDTO todoItemDTO = new TodoItemDTO(todo);

        return TypedResults.Ok(todoItemDTO);
    }

    return TypedResults.NotFound();
}