using Classes;
namespace  selectdtos;

public class TaskHistoryById
{
    public Guid TaskId { get; set; }
    public List<TaskHistories> History { get; set; }
}
