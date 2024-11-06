namespace ToDoList.Test.IntegrationTests;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Persistence;
<<<<<<< HEAD
=======
using ToDoList.Persistence.Repositories;
>>>>>>> ec372d91c93f60c082d6094137d2462abbd89a76
using ToDoList.WebApi.Controllers;

public class PostTests
{
    [Fact]
    public void Post_ValidRequest_ReturnsNewItem()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
<<<<<<< HEAD
        var controller = new ToDoItemsController(context);
=======
        var repository = new ToDoItemsRepository(context);
        var controller = new ToDoItemsController(repository);
        var request = new ToDoItemCreateRequestDto(
            Name: "Jmeno",
            Description: "Popis",
            IsCompleted: false
        );

        // Act
        var result = controller.Create(request);
        var resultResult = result.Result;
        var value = result.GetValue();

        // Assert
        Assert.IsType<CreatedAtActionResult>(resultResult);
        Assert.NotNull(value);

        Assert.Equal(request.Description, value.Description);
        Assert.Equal(request.IsCompleted, value.IsCompleted);
        Assert.Equal(request.Name, value.Name);
    }
}
