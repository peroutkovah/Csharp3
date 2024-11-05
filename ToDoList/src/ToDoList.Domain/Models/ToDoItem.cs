namespace ToDoList.Domain.Models;

using System.ComponentModel.DataAnnotations;

public class ToDoItem
{
    [Key]
<<<<<<< HEAD
    public int ToDoItemId { get; set; } //ef looks for field <ID> or <nameID>
    [Length(1,50)]
     public string Name { get; set; }
     [StringLength(250)]
=======
    public int ToDoItemId { get; set; } // ef core looks for field <id> or <nameId>
    [Length(1, 50)]
    public string Name { get; set; }
    [StringLength(250)]
>>>>>>> ec372d91c93f60c082d6094137d2462abbd89a76
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}
