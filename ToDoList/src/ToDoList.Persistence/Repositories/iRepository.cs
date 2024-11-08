

namespace ToDoList.Persistence.Repositories;


//repozitar T, kde T je trida..
public interface IRepository<T> where T : class
{
    //tohle je uplny zapis, nize je zjednoduseny
    //public void Create<T>(T item);
    public void Create(T item);

    // Read a single item by its identifier
    public T? ReadById(int id);

    // Read all items
    IEnumerable<T> ReadAll();

    // Update an existing item
    public void Update(T item);

    // Delete an item
    public void Delete(T item);

}

