namespace ToDoList.Test.IntegrationTests;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.Persistence;
using ToDoList.WebApi.Controllers;

public class PutTests
{
    [Fact]
    public void Put_ValidId_ReturnsNoContent()
    {
        // Arrange
<<<<<<< HEAD
        var path = AppContext.BaseDirectory;
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var controller = new ToDoItemsController(context);
=======
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var controller = new ToDoItemsController(context, null); // Docasny hack, nez z controlleru odstranime context.
>>>>>>> ec372d91c93f60c082d6094137d2462abbd89a76
        var toDoItem = new ToDoItem
        {
            Name = "Jmeno",
            Description = "Popis",
            IsCompleted = false
        };
        context.ToDoItems.Add(toDoItem);
        context.SaveChanges();

        var request = new ToDoItemUpdateRequestDto(
            Name: "Jine jmeno",
            Description: "Jiny popis",
            IsCompleted: true
        );

        // Act
        var result = controller.UpdateById(toDoItem.ToDoItemId, request);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public void Put_InvalidId_ReturnsNotFound()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
<<<<<<< HEAD
        var controller = new ToDoItemsController(context);
=======
        var controller = new ToDoItemsController(context, null); // Docasny hack, nez z controlleru odstranime context.
>>>>>>> ec372d91c93f60c082d6094137d2462abbd89a76
        var toDoItem = new ToDoItem
        {
            Name = "Jmeno",
            Description = "Popis",
            IsCompleted = false
        };
        context.ToDoItems.Add(toDoItem);
        context.SaveChanges();

        var request = new ToDoItemUpdateRequestDto(
            Name: "Jine jmeno",
            Description: "Jiny popis",
            IsCompleted: true
        );

        // Act
        var invalidId = -1;
        var result = controller.UpdateById(invalidId, request);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}
