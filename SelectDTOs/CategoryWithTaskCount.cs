using System;

namespace  selectdtos;

public class CategoryWithTaskCount
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public int TaskCount { get; set; }
}
