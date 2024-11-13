namespace ToDoList.Test.UnitTests;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class GetByIdUnitTests
{
    [Fact]
    public void Get_ReadByIdWhenSomeItemAvailable_ReturnsOk()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        var someId = 1;
        var itemToBeSelected = new ToDoItem
        {
            ToDoItemId = someId,
            Name = "testName",
            Description = "testDewscription",
            IsCompleted = false
        };
        //nastavim si, aby mi ten mock vracel tu moji chtenou Item
        repositoryMock.ReadById(someId).Returns(itemToBeSelected);


        // Act
        //spustim tu moji metodu
        var result = controller.ReadById(someId);
        var resultResult = result.Result;
        var selectedItem = result.GetValue();

        // Assert
        //testuju, zda je vysledek OK
        Assert.IsType<OkObjectResult>(resultResult);
        //testuju, zda se mi ta ma Item fakt vraci, tj. je shodna s tou z moku
        Assert.Equal(itemToBeSelected.ToDoItemId, selectedItem.Id);
        Assert.Equal(itemToBeSelected.Name, selectedItem.Name);
        Assert.Equal(itemToBeSelected.Description, selectedItem.Description);
        Assert.Equal(itemToBeSelected.IsCompleted, selectedItem.IsCompleted);
    }

    [Fact]
    public void Get_ReadByIdWhenItemIsNull_ReturnsNotFound()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        var someId = 1000;
        repositoryMock.ReadById(someId).ReturnsNull();

        // Act
        var result = controller.ReadById(someId);
        var resultResult = result.Result;

        // Assert
        Assert.IsType<NotFoundResult>(resultResult);
    }

    [Fact]
    public void Get_ReadByIdUnhandledException_ReturnsInternalServerError()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        var someId = 1000;
        repositoryMock.When(r => r.ReadById(someId)).Do(x => throw new Exception("Unhandled error"));

        // Act
        var result = controller.ReadById(someId);
        var resultResult = result.Result;

        // Assert
        Assert.IsType<ObjectResult>(resultResult);
        Assert.Equivalent(new StatusCodeResult(StatusCodes.Status500InternalServerError), resultResult);
    }
}
