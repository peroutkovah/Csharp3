namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Models;
using ToDoList.WebApi.Controllers;
using Microsoft.AspNetCore.Http;

public class DeleteTests
{
    [Fact]
    public void Delete_Item_DeletesItem()
    {
        // Arrange
        var controller = new ToDoItemsController();
        var toDoItem = new ToDoItem
        {
            ToDoItemId = 3,
            Name = "ÚkolNaSmazání",
            Description = "Úkol, co budu mazat",
            IsCompleted = false
        };
        ToDoItemsController.items.Add(toDoItem);

        // Act
        var result = controller.DeleteById(toDoItem.ToDoItemId);

        // Assert
        var noContentResult = Assert.IsType<NoContentResult>(result);
        Assert.Equal(StatusCodes.Status204NoContent, noContentResult.StatusCode);
    }
}
