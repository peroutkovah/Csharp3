namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Models;
using ToDoList.WebApi.Controllers;
using ToDoList.Domain.DTOs;
using Xunit;
using Microsoft.AspNetCore.Http;

public class PutTests
{
    [Fact]
    public void Put_Item_ChangeItem()
    {
        // Arrange
        var controller = new ToDoItemsController();
        var toDoItem = new ToDoItem
        {
            ToDoItemId = 3,
            Name = "Jmeno",
            Description = "Popis",
            IsCompleted = false
        };
        ToDoItemsController.items.Add(toDoItem);
        var changedItem = new ToDoItemUpdateRequestDto("Změněné jméno", "Změněný popis", true);

        // Act
        var result = controller.UpdateById(toDoItem.ToDoItemId, changedItem);

        // Assert
        var noContentResult = Assert.IsType<NoContentResult>(result);
        Assert.Equal(StatusCodes.Status204NoContent, noContentResult.StatusCode);


        var updatedItem = ToDoItemsController.items.Find(i => i.ToDoItemId == toDoItem.ToDoItemId);
        Assert.NotNull(updatedItem);
        Assert.Equal(changedItem.Name, updatedItem.Name);
        Assert.Equal(changedItem.Description, updatedItem.Description);
        Assert.Equal(changedItem.IsCompleted, updatedItem.IsCompleted);
        Assert.True(updatedItem.IsCompleted);

    }
}
