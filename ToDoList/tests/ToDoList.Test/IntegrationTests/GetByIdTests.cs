namespace ToDoList.Test.IntegrationTests;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.Persistence;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class GetByIdTests
{
    [Fact]
    public async Task GetById_ValidId_ReturnsItem()
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
        var result = await controller.ReadById(toDoItem.ToDoItemId);
        var resultResult =  result.Result; // This should be OkObjectResult on success
         // Extract the value (DTO)
        var value = result.GetValue();


        // Assert
        Assert.IsType<OkObjectResult>(resultResult);
        Assert.NotNull(value);


        Assert.Equal(toDoItem.ToDoItemId, value?.Id);
        Assert.Equal(toDoItem.Description, value?.Description);
        Assert.Equal(toDoItem.IsCompleted, value?.IsCompleted);
        Assert.Equal(toDoItem.Name, value?.Name);
    }

    [Fact]
    public async Task GetById_InvalidId_ReturnsNotFound()
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
        var invalidId = -1;
        var result = await controller.ReadById(invalidId);
        var resultResult = result.Result;

        // Assert
        Assert.IsType<NotFoundResult>(resultResult);
    }
}
