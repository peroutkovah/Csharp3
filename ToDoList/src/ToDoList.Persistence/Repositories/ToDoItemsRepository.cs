<<<<<<< HEAD


=======
>>>>>>> ec372d91c93f60c082d6094137d2462abbd89a76
namespace ToDoList.Persistence.Repositories;

using ToDoList.Domain.Models;

<<<<<<< HEAD

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


