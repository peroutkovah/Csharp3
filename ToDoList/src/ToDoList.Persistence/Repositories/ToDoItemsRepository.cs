

namespace ToDoList.Persistence.Repositories;

using ToDoList.Domain.Models;

//nova trida implementuje ten interface IRepository
public class ToDoItemsRepository : IRepository<ToDoItem>
{
    //zkopirovano z controlleru
    private readonly ToDoItemsContext context;

    public ToDoItemsRepository(ToDoItemsContext context)
    {
        this.context = context;
    }


    //todoitem repository implementuje
    public void Create(ToDoItem item)
    {
        context.ToDoItems.Add(item);
        context.SaveChanges();
    }


    public ToDoItem? ReadById(int id)
    {
        return context.ToDoItems.Find(id);
    }

    public IEnumerable<ToDoItem> ReadAll()
    {
        return context.ToDoItems.ToList();
    }

    public void Update(ToDoItem item)
    {
        var itemTobeUpdate = context.ToDoItems.Find(item.ToDoItemId);

        itemTobeUpdate.Name = item.Name;
        if (itemTobeUpdate == null)
        {
            throw new ArgumentOutOfRangeException($"ToDo item with ID {item.ToDoItemId} not found.");
        }
        itemTobeUpdate.Description = item.Description;
        itemTobeUpdate.IsCompleted = item.IsCompleted;
        context.SaveChanges();
    }

    public void Delete(ToDoItem item)
    {
        var itemToDelete = context.ToDoItems.Find(item.ToDoItemId);
        context.ToDoItems.Add(item);
        context.SaveChanges();
    }
}

