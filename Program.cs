

using Classes;
using interfaces;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


IUser userService = new UserService();

app.MapPost("api/users", async (User user) =>
{
    return await userService.CreateAsync(user);
});

app.MapPut("api/users", async (User user) =>
{
    return await userService.UpdateAsync(user);
});
app.MapDelete("api/users{id}", async (Guid id) =>
{
    return await userService.DeleteAsync(id);
});

app.MapGet("api/users", async () =>
{
   return await userService.GetAllUsersAsync();  
});

app.MapGet("api/users{id}", async (Guid id) =>
{
    return await userService.GetByIdAsync(id);
});




ICagetories categoryService = new CategoryServices();

app.MapPost("api/categories", async (Categories category) =>
{
    return await categoryService.CreateCategoryAsync(category);
});

app.MapPut("api/categories", async (Categories category) =>
{
    return await categoryService.UpdateCategoryAsync(category);
});
app.MapDelete("api/categories{id}", async (Guid id) =>
{
    return await categoryService.DeleteCategoryAsync(id);
});

app.MapGet("api/categories", async () =>
{
    return await categoryService.GetAllCategoriesAsync();
});

app.MapGet("api/categories{id}", async (Guid id) =>
{
    return await categoryService.GetByIdAsync(id);
});







IComments commentService = new CommentsService();

app.MapPost("api/comments", async (Comments comment) =>
{
    return await commentService.CreateCommentAsync(comment);
});

app.MapPut("api/comments", async (Comments comment) =>
{
    return await commentService.UpdateCommentAsync(comment);
});
app.MapDelete("api/comments{id}", async (Guid id) =>
{
    return await commentService.DeleteCommentAsync(id);
});

app.MapGet("api/comments", async () =>
{
    return await commentService.GetAllComments();
});

app.MapGet("api/comments{id}", async (Guid id) =>
{
    return await commentService.GetCommentByIdAsync(id);
});





ITask taskService = new TaskService();

app.MapPost("api/tasks", async (Tasks task) =>
{
    return await taskService.Create(task);
});

app.MapPut("api/tasks", async (Tasks task) =>
{
    return await taskService.Update(task);
});
app.MapDelete("api/tasks{id}", async (Guid id) =>
{
    return await taskService.Delete(id);
});

app.MapGet("api/tasks", async () =>
{
    return await taskService.GetAll();
});

app.MapGet("api/tasks{id}", async (Guid id) =>
{
    return await taskService.GetById(id);
});





ITaskAttachments taskAttachmentsService = new TaskAttachmentsService();

app.MapPost("api/task-attachments", async (TaskAttachments taskAttachments) =>
{
    return await taskAttachmentsService.CreateAsync(taskAttachments);
});

app.MapPut("api/task-attachments", async (TaskAttachments taskAttachments) =>
{
    return await taskAttachmentsService.UpdateAsync(taskAttachments);
});
app.MapDelete("api/task-attachments{id}", async (Guid id) =>
{
    return await taskAttachmentsService.DeleteAsync(id);
});

app.MapGet("api/task-attachments", async () =>
{
    return await taskAttachmentsService.GetAllAsync();
});

app.MapGet("api/task-attachments{id}", async (Guid id) =>
{
    return await taskAttachmentsService.GetByIdAsync(id);
});




ITaskHistory taskHistoryService = new TaskHistoryService();

app.MapPost("api/task-history", async (TaskHistories taskHistory) =>
{
    return await taskHistoryService.CreateAsync(taskHistory);
});

app.MapPut("api/task-history", async (TaskHistories taskHistory) =>
{
    return await taskHistoryService.UpdateAsync(taskHistory);
});
app.MapDelete("api/task-history{id}", async (Guid id) =>
{
    return await taskHistoryService.DeleteAsync(id);
});

app.MapGet("api/task-history", async () =>
{
    return await taskHistoryService.GetAllAsync();
});

app.MapGet("api/task-history{id}", async (Guid id) =>
{
    return await taskHistoryService.GetByIdAsync(id);
});







QueryServices queryServices = new QueryServices();

app.MapGet("api/select-user-task", async () =>
{
    return await queryServices.SelectUserTasksAsync();
});

app.MapGet("api/select-category-taskcount", async () =>
{
    return await queryServices.SelectCategoryTasksCountAsync();
});

app.MapGet("api/select-task-by-priority{priority}", async (string priority) =>
{
    return await queryServices.SelectTasksByPriority( priority);
});

app.MapGet("api/select-tasks-users-categories",async ()=>
{
    return await queryServices.SelectTasksUsersCategoriesAsync();
});


app.MapGet("api/select-task-order-by-duedate", async () =>
{
    return await queryServices.SelectTasksOrderByDueDateAsync(); 
});


app.MapGet("api/select-taskhistory-by-taskid", async (Guid taskId) =>
{
    return await queryServices.SelectTaskHistroyByTaskIdAsync(taskId); 
});

app.MapGet("api/select-comment-task-by-user", async (Guid taskId, Guid userId) =>
{
    return await queryServices.SelectCommentTaskFilteringUserAsync(taskId, userId);
});


app.MapGet("api/select-task-attachment-by-taskid", async (Guid taskId) =>
{
    return await queryServices.SelectTaskAttachmentsUserAsync(taskId);
});

app.MapGet("api/select-task-filtering=by-duedate", async (string date)=>
{
    return await queryServices.selectTaskFiltringDueDateAsync(date);
});


app.MapGet("api/select-task-filtring-by-priority-and-iscompleted", async (bool isCompleted, string priority) =>
{
    return await queryServices.SelectAllTaskFiltringIsStatuseAndPriorityAsync(isCompleted, priority);
});



app.Run();
