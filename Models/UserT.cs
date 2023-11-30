using System;
using System.Collections.Generic;

namespace ToDoList_API.Models;

public partial class UserT
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public virtual ICollection<TaskT> TaskTs { get; } = new List<TaskT>();
}
