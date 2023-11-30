namespace ToDoList_API.Models
{
    public partial class TaskContext : Models.ToDoListContext
    {
        public static Models.ToDoListContext context { get; } = new Models.ToDoListContext();
    }
}
