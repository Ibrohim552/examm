namespace Classes;


using System;

public class TaskHistories
{
    public Guid Id { get; set; }
    public Guid TaskId { get; set; }
    public string ChangeDescription { get; set; }
    public DateTime ChangedAt { get; set; } = DateTime.Now;
}
