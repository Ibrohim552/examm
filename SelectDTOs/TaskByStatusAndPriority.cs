using System;
namespace  selectdtos;


public class TaskByStatusAndPriority
{
    public Guid TaskId { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
    public int Priority { get; set; }
}
