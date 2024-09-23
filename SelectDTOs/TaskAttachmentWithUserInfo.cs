using System;
using Classes;
namespace  selectdtos;

public class TaskAttachmentWithUserInfo
{
    public Guid TaskId { get; set; }
    public string FilePath { get; set; }
    public User User { get; set; }
    public DateTime CreatedAt { get; set; }
}
