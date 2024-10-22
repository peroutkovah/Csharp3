namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Models;
using ToDoList.WebApi.Controllers;
using ToDoList.Domain.DTOs;

public class PostTests
{
    [Fact]
    public void Post_Item_CreateItem()
    {
        // Arrange
        var controller = new ToDoItemsController();
        var newItem = new ToDoItemCreateRequestDto("Háčkovat", "Uháčkuj svetr pro Barbie", true);

        // Act
        var result = controller.Create(newItem);
        var resultResult = result.Result;
        var value = result.GetValue();

        // Assert
        Assert.IsType<CreatedAtActionResult>(resultResult);
        Assert.NotNull(value);

        //Assert.Equal(newItem.ToDoItemId, value.Id);
        Assert.Equal(newItem.Description, value.Description);
        Assert.Equal(newItem.IsCompleted, value.IsCompleted);
        Assert.Equal(newItem.Name, value.Name);
    }
}
