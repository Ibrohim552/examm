using System;
using Classes;
namespace  selectdtos;


public class TaskWithUserAndCategory
{
    public Guid TaskId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public User User { get; set; }
    public Categories Category { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? DueDate { get; set; }
}
