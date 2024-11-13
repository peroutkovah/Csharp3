namespace ToDoList.Test.UnitTests;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class PutUnitTests
{
    [Fact]
    public void Put_UpdateByIdWhenItemUpdated_ReturnsNoContent()
    {
        //Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        var someId = 1;
        repositoryMock.ReadById(someId).Returns(new ToDoItem
        {
            Name = "Jmeno",
            Description = "Popis",
            IsCompleted = false
        }
        );

        var request = new ToDoItemUpdateRequestDto("Zmeněné_Jmeno","Změněný_Popis",true);


        //Act
        var result = controller.UpdateById(someId, request);

        //Assert
        //kontrola, ze se mi ReadById naplni pouze jednou
        repositoryMock.Received(1).ReadById(someId);
        repositoryMock.Received(1).Update(Arg.Is<ToDoItem>(item =>
        item.Name == "Zmeněné_Jmeno" &&
        item.Description == "Změněný_Popis" &&
        item.IsCompleted == true
        ));
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public void Put_UpdateByIdWhenIdNotFound_ReturnsNotFound()
    {
        //Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        var someId = 1;
        repositoryMock.ReadById(someId).ReturnsNull();

        var request = new ToDoItemUpdateRequestDto("Zmeněné_Jmeno","Změněný_Popis",true);

        //Act
        var result = controller.UpdateById(someId, request);

        //Assert
        repositoryMock.Received(1).ReadById(someId);
        //repositoryMock.Received(1).DeleteById(someId);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Put_UpdateByIdUnhandledException_ReturnsInternalServerError()
    {
        //Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        var someId = 3;
        repositoryMock.When(r => r.ReadById(someId)).Do(x => throw new Exception("Unhandled error"));

        var request = new ToDoItemUpdateRequestDto("Zmeněné_Jmeno","Změněný_Popis",true);

        //Act
        var result = controller.UpdateById(someId, request);


        //Assert
        var objectResult = result as ObjectResult;
        Assert.NotNull(objectResult);  // Ensure that the result is not null
        Assert.Equal(500, objectResult.StatusCode);  // Ensure that the status code is 500 (InternalServerError)

    }

}
