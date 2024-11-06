namespace ToDoList.Test.UnitTests;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using ToDoList.Domain.Models;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class GetUnitTests
{
    [Fact]
    public void Get_ReadAllAndSomeItemIsAvailable_ReturnsOk()
    {
        //Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        //nastavim si tady repozitar
        // repositoryMock.When().Do(); //genericke kdyz tak
        // repositoryMock.ReadAll().Returns(); // nastavujeme return value
        // repositoryMock.ReadAll().Throws(); // vyhazujeme výjimku
        // repositoryMock.Received().ReadAll(); // kontrolujeme zavolání metody


        repositoryMock.ReadAll().Returns(
            [new ToDoItem
            {
                Name="testName",
                Description ="testDewscription",
                IsCompleted = false
            }
            ]);
        //Act
        var result = controller.Read();
        var resultResult = result.Result;

        //Assert
        Assert.IsType<OkObjectResult>(resultResult);
        repositoryMock.Received(1).ReadAll();

    }

    [Fact]
    public void Get_ReadAllNoItemAvailable_ReturnNotFound()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        // repositoryMock.ReadAll().ReturnsNull();
        repositoryMock.ReadAll().Returns(null as IEnumerable<ToDoItem>);
        // Act
        var result = controller.Read();
        var resultResult = result.Result;
        // Assert
        Assert.IsType<NotFoundResult>(resultResult);
        repositoryMock.Received(1).ReadAll();
    }



  [Fact]
    public void Get_ReadAllExceptionOccured_ReturnInternalServerError()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        repositoryMock.ReadAll().Throws(new Exception());
        // Act
        var result = controller.Read();
        var resultResult = result.Result;
        // Assert
        Assert.IsType<ObjectResult>(resultResult);
        repositoryMock.Received(1).ReadAll();
        Assert.Equivalent(new StatusCodeResult(StatusCodes.Status500InternalServerError), resultResult);
    }


}
