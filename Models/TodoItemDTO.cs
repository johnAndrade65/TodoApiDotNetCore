using TodoAPI;

public class TodoItemDTO
{
    //Propriedades do modelo de dados
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
    public string? Message { get; set; }

    public TodoItemDTO() { }

    public TodoItemDTO(Todo todoItem) =>
        (Id, Name, IsComplete, Message) = (todoItem.Id, todoItem.Name, todoItem.IsComplete, todoItem.Message);
}
