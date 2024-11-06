
namespace ToDoList.Persistence.Repositories;

using ToDoList.Domain.Models;


public class ToDoItemsRepository: IRepository<ToDoItem>
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
}


