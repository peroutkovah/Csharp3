

namespace ToDoList.Persistence.Repositories;


using System.Runtime.InteropServices;
using ToDoList.Domain.Models;

//repozitar T, kde T je trida..
public interface IRepository<T> where T : class
    {
       public void Create(T item);
    }

