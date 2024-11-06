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
        //repositoryMock.Received(1).DeleteById(someId);
        Assert.IsType<NotFoundResult>(result);
    }



}
