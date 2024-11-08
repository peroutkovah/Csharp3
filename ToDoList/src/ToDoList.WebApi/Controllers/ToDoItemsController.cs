namespace ToDoList.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.Persistence;
using ToDoList.Persistence.Repositories;


[ApiController]
[Route("api/[controller]")]
public class ToDoItemsController : ControllerBase
{
    //bez contextu bude finalni stav - tohle odstranim a budud spolehat jen na rpozitar
    private readonly ToDoItemsContext context;
    private readonly IRepository<ToDoItem> repository;

    public IRepository<ToDoItem> RepositoryMock { get; }

    /* //tenhle konstruktor, pak odstranim
    public ToDoItemsController(ToDoItemsContext context, IRepository<ToDoItem> repository)
    {
        this.context = context;
        this.repository = repository;
    } */

    public ToDoItemsController(IRepository<ToDoItem> repository)
    {
        this.repository = repository;
    }

    //public ToDoItemsController(IRepository<ToDoItem> repositoryMock) => RepositoryMock = repositoryMock;

    [HttpPost]
    public ActionResult<ToDoItemGetResponseDto> Create(ToDoItemCreateRequestDto request)
    {
        //map to Domain object as soon as possible
        var item = request.ToDomain();

        //try to create an item
        try
        {
            //nahradim conntextem
            // item.ToDoItemId = items.Count == 0 ? 1 : items.Max(o => o.ToDoItemId) + 1;
            // items.Add(item);

            //presunu do repozitare
            //context.ToDoItems.Add(item);
            //context.SaveChanges();

            repository.Create(item);

        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        //respond to client
        return CreatedAtAction(
            nameof(ReadById),
            new { toDoItemId = item.ToDoItemId },
            ToDoItemGetResponseDto.FromDomain(item)); //201
    }

    [HttpGet("{toDoItemId:int}")]
    public ActionResult<ToDoItemGetResponseDto> ReadById(int toDoItemId)
    {
        //try to retrieve the item by id
        ToDoItem? itemToGet;
        try
        {   //tohle nahradim tim repozitarem
            //itemToGet = context.ToDoItems.Find(toDoItemId);
          itemToGet= repository.ReadById(toDoItemId);

        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        //respond to client
        return (itemToGet is null)
            ? NotFound() //404
            : Ok(ToDoItemGetResponseDto.FromDomain(itemToGet)); //200
    }

    [HttpGet]
    public ActionResult<IEnumerable<ToDoItemGetResponseDto>> Read()
    {
        //List<ToDoItem> itemsToGet;
        IEnumerable<ToDoItem> itemsToGet;

        try
        {
            itemsToGet = repository.ReadAll();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        //respond to client
        return (itemsToGet is null || itemsToGet.Count() is 0)
            ? NotFound() //404
            : Ok(itemsToGet.Select(ToDoItemGetResponseDto.FromDomain)); //200
    }


    [HttpPut("{toDoItemId:int}")]
    public IActionResult UpdateById(int toDoItemId, [FromBody] ToDoItemUpdateRequestDto request)
    {
        //map to Domain object as soon as possible
        var updatedItem = request.ToDomain();
        updatedItem.ToDoItemId = toDoItemId;


        //try to update the item by retrieving it with given id
        try
        {
            //retrieve the item
            /* var itemTobeUpdate = context.ToDoItems.Find(toDoItemId);
            if (itemTobeUpdate == null)
            {
                return NotFound(); //404
            }

            itemTobeUpdate.Name = updatedItem.Name;
            itemTobeUpdate.Description = updatedItem.Description;
            itemTobeUpdate.IsCompleted = updatedItem.IsCompleted;
            context.SaveChanges(); */
            var itemTobeUpdate =repository.ReadById(toDoItemId);
            repository.Update(itemTobeUpdate);

        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        //respond to client
        return NoContent(); //204
    }

    [HttpDelete("{toDoItemId:int}")]
    public IActionResult DeleteById(int toDoItemId)
    {
        //try to delete the item
        try
        {
            //var itemToDelete = context.ToDoItems.Find(toDoItemId);
            var itemToDelete = repository.ReadById(toDoItemId);
            if (itemToDelete is null)
            {
                return NotFound(); //404
            }
            repository.Delete(itemToDelete);

        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }

        //respond to client
        return NoContent(); //204
    }
}
