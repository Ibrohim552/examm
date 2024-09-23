namespace Classes;

using System;

public class Tasks
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; } = false;
    public DateTime? DueDate { get; set; }
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public int Priority { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
