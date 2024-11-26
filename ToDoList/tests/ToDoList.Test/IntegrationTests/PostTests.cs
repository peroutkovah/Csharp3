namespace ToDoList.Test.IntegrationTests;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;

using ToDoList.Persistence;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class PostTests
{
    [Fact]
    public async Task Post_ValidRequest_ReturnsNewItem()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var repository = new ToDoItemsRepository(context);
        var controller = new ToDoItemsController(repository);
        var request = new ToDoItemCreateRequestDto(
            Name: "Jmeno",
            Description: "Popis",
            IsCompleted: false,
            Category: null
        );

        // Act
        var result = await controller.Create(request);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var createdItem = Assert.IsType<ToDoItemGetResponseDto>(createdResult.Value);

        Assert.Equal(request.Description, createdItem.Description);
        Assert.Equal(request.IsCompleted, createdItem.IsCompleted);
        Assert.Equal(request.Name, createdItem.Name);
        Assert.Equal(request.Category, createdItem.Category);
    }
}
