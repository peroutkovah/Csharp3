namespace ToDoList.Test.UnitTests;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using ToDoList.Domain.Models;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class DeleteUnitTests
{
    [Fact]
    public void Delete_ValidItemID_ReturnsNoContent()
    {
        //Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        //nastavim si tady repozitar
        // repositoryMock.When().Do(); //genericke kdyz tak
        // repositoryMock.ReadAll().Returns(); // nastavujeme return value
        // repositoryMock.ReadAll().Throws(); // vyhazujeme výjimku
        // repositoryMock.Received().ReadAll(); // kontrolujeme zavolání metody
        repositoryMock.ReadById(Arg.Any<int>()).Returns(new ToDoItem
        {
            Name = "testName",
            Description = "testDewscription",
            IsCompleted = false
        }
            );
        var someId = 1;

        //Act
        var result = controller.DeleteById(someId);


        //Assert
        repositoryMock.Received(1).ReadById(someId);
        repositoryMock.Received(1).DeleteById(someId);
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public void Delete_InvalidItemId_ReturnsNotFound()
    {
        //Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        repositoryMock.ReadById(Arg.Any<int>()).ReturnsNull();
        var someId = 1;

        //Act
        var result = controller.DeleteById(someId);

        //Assert
        repositoryMock.Received(1).ReadById(someId);
        // testuju, ze DeletedById nebylo volano, kdyz je NUll
        repositoryMock.DidNotReceive().DeleteById(someId);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Delete_DeleteByIdUnhandledException_ReturnsInternalServerError()
    {
        //Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        var someId = 3;
        repositoryMock.When(r => r.ReadById(someId)).Do(x => throw new Exception("Unhandled error"));

        //Act
        var result = controller.DeleteById(someId);


        //Assert
        var objectResult = result as ObjectResult;
        Assert.NotNull(objectResult);  // Ensure that the result is not null
        Assert.Equal(500, objectResult.StatusCode);  // Ensure that the status code is 500 (InternalServerError)

    }

}
