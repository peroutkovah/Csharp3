namespace ToDoList.Test.IntegrationTests;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.Persistence;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class GetTests
{
    [Fact]
    public async Task Get_AllItems_ReturnsAllItems()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var repository = new ToDoItemsRepository(context);
        var controller = new ToDoItemsController(repository);

        var toDoItem = new ToDoItem
        {
            Name = "Jmeno",
            Description = "Popis",
            IsCompleted = false
        };
        await context.ToDoItems.AddAsync(toDoItem);
        await context.SaveChangesAsync();

        // Act
        var result = await controller.Read();
        var resultResult = result.Result;
        var value = result.GetValue();

        // Assert
        Assert.IsType<OkObjectResult>(resultResult);
        Assert.NotNull(value);

        var item = value.First(i => i.Id == toDoItem.ToDoItemId);
        Assert.NotNull(item);
        Assert.Equal(toDoItem.ToDoItemId, item.Id);
        Assert.Equal(toDoItem.Description, item.Description);
        Assert.Equal(toDoItem.IsCompleted, item.IsCompleted);
        Assert.Equal(toDoItem.Name, item.Name);
    }
}
