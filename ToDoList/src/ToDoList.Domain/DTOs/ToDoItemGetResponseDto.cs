namespace ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;

public record class ToDoItemGetResponseDto(int Id, string Name, string Description, bool IsCompleted, string? Category) //let client know the Id
{
    public static ToDoItemGetResponseDto FromDomain(ToDoItem item) => new(item.ToDoItemId, item.Name, item.Description, item.IsCompleted, item.Category);

    public override string ToString() => $"Id: {Id}, Name: {Name}, Completed: {IsCompleted}. Category: {Category}";
}

