namespace Classes;

using System;

public class TaskAttachments
{
    public Guid Id { get; set; }
    public Guid TaskId { get; set; }
    public string FilePath { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
