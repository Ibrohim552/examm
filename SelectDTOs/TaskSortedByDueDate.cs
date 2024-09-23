using System;
namespace  selectdtos;


public class TaskSortedByDueDate
{
    public Guid TaskId { get; set; }
    public string Title { get; set; }
    public DateTime? DueDate { get; set; }
    public bool IsCompleted { get; set; }
}
