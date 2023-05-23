namespace TodoAPI
{
    public class Todo
    {
        //Propriedades do modelo de dados
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public string? Message { get; set; }
    }
}
