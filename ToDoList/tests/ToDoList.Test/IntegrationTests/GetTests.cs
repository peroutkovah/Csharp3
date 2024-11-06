<<<<<<< HEAD
namespace ToDoList.Test;
=======
namespace ToDoList.Test.IntegrationTests;
>>>>>>> ec372d91c93f60c082d6094137d2462abbd89a76

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Models;
using ToDoList.Persistence;
using ToDoList.WebApi.Controllers;

public class GetTests
{
    [Fact]
    public void Get_AllItems_ReturnsAllItems()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
<<<<<<< HEAD
        var controller = new ToDoItemsController(context);
        var toDoItem = new ToDoItem
        {
            ToDoItemId = 1,
=======
        var controller = new ToDoItemsController(context, null); // Docasny hack, nez z controlleru odstranime context.

        var toDoItem = new ToDoItem
        {
>>>>>>> ec372d91c93f60c082d6094137d2462abbd89a76
            Name = "Jmeno",
            Description = "Popis",
            IsCompleted = false
        };
<<<<<<< HEAD
        controller.items.Add(toDoItem);
=======
        context.ToDoItems.Add(toDoItem);
        context.SaveChanges();
>>>>>>> ec372d91c93f60c082d6094137d2462abbd89a76

        // Act
        var result = controller.Read();
        var resultResult = result.Result;
        var value = result.GetValue();

        // Assert
        Assert.IsType<OkObjectResult>(resultResult);
        Assert.NotNull(value);

<<<<<<< HEAD
        var firstItem = value.First();
        Assert.Equal(toDoItem.ToDoItemId, firstItem.Id);
        Assert.Equal(toDoItem.Description, firstItem.Description);
        Assert.Equal(toDoItem.IsCompleted, firstItem.IsCompleted);
        Assert.Equal(toDoItem.Name, firstItem.Name);
    }

    [Fact]
    public void Get_NoItems_ReturnsNotFound()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var controller = new ToDoItemsController(context);

        // Act
        var result = controller.Read();
        var resultResult = result.Result;

        // Assert
        Assert.IsType<NotFoundResult>(resultResult);
=======
        var item = value.First(i => i.Id == toDoItem.ToDoItemId);
        Assert.NotNull(item);
        Assert.Equal(toDoItem.ToDoItemId, item.Id);
        Assert.Equal(toDoItem.Description, item.Description);
        Assert.Equal(toDoItem.IsCompleted, item.IsCompleted);
        Assert.Equal(toDoItem.Name, item.Name);
>>>>>>> ec372d91c93f60c082d6094137d2462abbd89a76
    }
}
