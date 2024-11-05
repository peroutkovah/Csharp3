namespace ToDoList.Persistence;

using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Models;

<<<<<<< HEAD
//trida, ktera nas napoji na databazi
public class ToDoItemsContext: DbContext
=======
public class ToDoItemsContext : DbContext
>>>>>>> ec372d91c93f60c082d6094137d2462abbd89a76
{
    private readonly string connectionString;
    public ToDoItemsContext(string connectionString = "Data Source=../../data/localdb.db")
    {
<<<<<<< HEAD
        this.connectionString=connectionString;
        this.Database.Migrate();
    }

    public DbSet<ToDoItem> ToDoItems {get; set;}
=======
        this.connectionString = connectionString;
        this.Database.Migrate();
    }

    public DbSet<ToDoItem> ToDoItems { get; set; }
>>>>>>> ec372d91c93f60c082d6094137d2462abbd89a76

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString);
    }
<<<<<<< HEAD

=======
>>>>>>> ec372d91c93f60c082d6094137d2462abbd89a76
}
