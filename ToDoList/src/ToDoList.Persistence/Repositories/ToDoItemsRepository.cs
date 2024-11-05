<<<<<<< HEAD


=======
>>>>>>> ec372d91c93f60c082d6094137d2462abbd89a76
namespace ToDoList.Persistence.Repositories;

using ToDoList.Domain.Models;

<<<<<<< HEAD

public class ToDoItemsRepository: IRepository<ToDoItem>
{
    //zkopirovano z controlleru
=======
public class ToDoItemsRepository : IRepository<ToDoItem>
{
>>>>>>> ec372d91c93f60c082d6094137d2462abbd89a76
    private readonly ToDoItemsContext context;

    public ToDoItemsRepository(ToDoItemsContext context)
    {
        this.context = context;
    }

<<<<<<< HEAD

    //todoitem repository implementuje
=======
>>>>>>> ec372d91c93f60c082d6094137d2462abbd89a76
    public void Create(ToDoItem item)
    {
        context.ToDoItems.Add(item);
        context.SaveChanges();
<<<<<<< HEAD
     }
}

=======
    }
}
>>>>>>> ec372d91c93f60c082d6094137d2462abbd89a76
