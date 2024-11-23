
namespace ToDoList.Persistence.Repositories;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Models;


public class ToDoItemsRepository: IRepositoryAsync<ToDoItem>
{
    //zkopirovano z controlleru

    private readonly ToDoItemsContext context;

    public ToDoItemsRepository(ToDoItemsContext context)
    {
        this.context =  context;
    }

    //todoitem repository implementuje

    public async Task CreateAsync(ToDoItem item)
    {
        await context.ToDoItems.AddAsync(item);
        await context.SaveChangesAsync();
    }
    public async Task<IEnumerable<ToDoItem>> ReadAllAsync()
    {
       return await context.ToDoItems.ToListAsync();
    }
    public async Task<ToDoItem?>  ReadByIdAsync(int id)
    {
        return await context.ToDoItems.FindAsync(id);

    }
    public async Task UpdateAsync(ToDoItem item)
    {

        context.Entry(item).CurrentValues.SetValues(item);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ToDoItem item)
    {
        context.ToDoItems.Remove(item);
        await context.SaveChangesAsync();
    }
}


