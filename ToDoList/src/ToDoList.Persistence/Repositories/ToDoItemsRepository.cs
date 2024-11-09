

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

        if (itemTobeUpdate == null)
        {
            throw new ArgumentOutOfRangeException($"ToDo item with ID {item.ToDoItemId} not found.");
        }

        itemTobeUpdate.Name = item.Name;
        itemTobeUpdate.Description = item.Description;
        itemTobeUpdate.IsCompleted = item.IsCompleted;
        context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var itemToDelete = context.ToDoItems.Find(id);
        if (itemToDelete == null)
        {
            throw new ArgumentOutOfRangeException($"ToDo item with ID {itemToDelete.ToDoItemId} not found.");
        }
        context.ToDoItems.Remove(itemToDelete);
        context.SaveChanges();
    }
}

