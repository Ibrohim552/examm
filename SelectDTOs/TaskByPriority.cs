using System;
namespace  selectdtos;


public class TaskByPriority
{
    public Guid TaskId { get; set; }
    public string Title { get; set; }
    public int Priority { get; set; }
    public bool IsCompleted { get; set; }
}
