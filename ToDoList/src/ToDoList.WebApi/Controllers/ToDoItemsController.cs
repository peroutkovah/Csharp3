namespace ToDoList.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class ToDoItemsController : ControllerBase
{
    private static readonly List<ToDoItem> items = [];

    [HttpPost]
    public IActionResult Create(ToDoItemCreateRequestDto request)
    {
        //map to Domain object as soon as possible
        var item = request.ToDomain();

        //try to create an item
        try
        {
            item.ToDoItemId = items.Count == 0 ? 1 : items.Max(o => o.ToDoItemId) + 1;
            items.Add(item);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        //respond to client
        // return NoContent(); //201 //tato metoda z nějakého důvodu vrací status code No Content 204, zjištujeme proč ;)
        return CreatedAtAction(nameof(Create), new { id = item.ToDoItemId }, ToDoItemGetResponseDto.FromDomain(item));
    }

    [HttpGet]
    public IActionResult Read()
    {
        try
        {
            var countItems = items.Count;
            if (countItems == 0)
            {
                return NotFound(new { Message = $"List s úkoly je prázdný."});

            }

            var allItems = items.Select(ToDoItemGetResponseDto.FromDomain).ToList();
            return Ok(allItems);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);;
        }
    }

    [HttpGet("{toDoItemId:int}")]
    public IActionResult ReadById(int toDoItemId)
    {
        try
        {
            var toDoItem = items.Find(item => item.ToDoItemId == toDoItemId);
 
            if (toDoItem == null)
            {
                /* var notFoundResponse = new
                {
                    Message = $"Úkol s ID {toDoItemId} neexistuje."
                };

                return NotFound(notFoundResponse); */

                return NotFound(new { Message = $"Úkol s ID {toDoItemId} neexistuje."});

            }

            return Ok(ToDoItemGetResponseDto.FromDomain(toDoItem));
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);;
        }
    }

    [HttpPut("{toDoItemId:int}")]
    public IActionResult UpdateById(int toDoItemId, [FromBody] ToDoItemUpdateRequestDto request)
    {
        try
        {
            //Pouziti FindIndex pro najiit ITEMu v seznamu
            int index = items.FindIndex(item => item.ToDoItemId == toDoItemId);
 
            if (index == -1)
            {
                return NotFound(new { Message = $"Úkol s ID {toDoItemId} neexistuje." });
            }

            var toDoItem = items[index];
            toDoItem.Name = request.Name;
            toDoItem.Description = request.Description;
            toDoItem.IsCompleted = request.IsCompleted;

            return NoContent();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);;
        }
    }

    [HttpDelete("{toDoItemId:int}")]
    public IActionResult DeleteById(int toDoItemId)
    {
        try
        {
            var toDoItem = items.Find(item => item.ToDoItemId == toDoItemId);
 
            if (toDoItem == null)
            {
                return NotFound($"msg: Úkol s ID {toDoItemId} neexistuje. Není možné ho smazat.");
            }
            items.Remove(toDoItem);
            return NoContent();
            //return Ok(new { Message = $"Úkol s ID {toDoItemId} byl smazán."});
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);;
        }
    }
}
