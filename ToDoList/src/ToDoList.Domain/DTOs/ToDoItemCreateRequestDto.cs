namespace ToDoList.Domain.DTOs;

using ToDoList.Domain.Models;


//kdyz je to null

public record ToDoItemCreateRequestDto(string Name, string Description, bool IsCompleted, string? Category) //id is generated
{

    public ToDoItem ToDomain() => new() { Name = Name, Description = Description, IsCompleted = IsCompleted, Category = Category };
}
