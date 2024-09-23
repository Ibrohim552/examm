using System;
namespace  selectdtos;

public class CommentsByTaskAndUser
{
    public Guid TaskId { get; set; }
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string CommentContent { get; set; }
    public DateTime CreatedAt { get; set; }
}
