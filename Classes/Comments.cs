namespace Classes;



public class Comments
{
    public Guid Id { get; set; } 
    public Guid TaskId { get; set; } 
    public Guid UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now; 
}
