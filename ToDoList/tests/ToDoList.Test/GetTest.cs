
namespace ToDoList.Test;
using System;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Models;
using ToDoList.WebApi.Controllers;

public class GetTest
{
    [Fact]

    public void Get_AllItems_ReturnAllItems()
    {
        // Arange
        var controller = new ToDoItemsController();
        var toDoItem = new ToDoItem();
        ToDoItemsController.items.Add(toDoItem);

        // Act
        var result = controller.Read();
        var value = result.Value;
        var resultResult = result.Result;


        // Assert
        Assert.True(resultResult is OkResult);
        Assert.IsType<OkObjectResult>(resultResult);

    }
}

