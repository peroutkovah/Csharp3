namespace ToDoList.Persistence;

using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Models;

//trida, ktera nas napoji na databazi
public class ToDoItemsContext: DbContext
{
    private readonly string connectionString;
    public ToDoItemsContext(string connectionString = "Data Source=../../data/localdb.db")
    {
        this.connectionString=connectionString;
        this.Database.Migrate();
    }

    public DbSet<ToDoItem> ToDoItems {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString);
    }

}
