using System;
using System.Collections.Generic;
namespace  selectdtos;

public class UserWithTasks
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public List<Task> Tasks { get; set; }
}
