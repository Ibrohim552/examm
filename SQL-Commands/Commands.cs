namespace Commands;


public class Commands
{
    public const string connectionstring = "Server=localhost;Port=5432;Database=Education_Center_db;User Id=postgres;Password=postgres;";


 #region Inserts
    public const string InsertCategory = @"INSERT INTO Categories(Id, Name, CreatedAt) 
                                           VALUES(@CategoryId, @CategoryName, @CreatedAt)";
    public const string InsertTask = @"INSERT INTO Tasks(Id, Title, Description, IsCompleted, DueDate, UserId, CategoryId, Priority, CreatedAt) 
                                       VALUES(@TaskId, @Title, @Description, @IsCompleted, @DueDate, @UserId, @CategoryId, @Priority, @CreatedAt)";
    public const string InsertUser = "INSERT INTO users (UserName, Email, PasswordHash,CreatedAt) VALUES (@UserName,@Email, @PasswordHash,@CreatedAt)";
    public const string InsertTaskHistory = @"INSERT INTO TaskHistory(Id, TaskId, ChangeDescription, ChangedAt) 
                                              VALUES(@Id, @TaskId, @ChangeDescription, @ChangedAt)";
    public const string InsertComment = @"INSERT INTO Comments(Id, TaskId, UserId, Content, CreatedAt) 
                                          VALUES(@Id, @TaskId, @UserId, @Content, @CreatedAt)";
    public const string InsertTaskAttachment = @"INSERT INTO TaskAttachments(Id, TaskId, FilePath, CreatedAt) 
                                                 VALUES(@Id, @TaskId, @FilePath, @CreatedAt)";
    #endregion

      #region Updates
    public const string UpdateCategory = @"UPDATE Categories SET Name = @CategoryName, CreatedAt = @CreatedAt WHERE Id = @CategoryId";
    public const string UpdateTask = @"UPDATE Tasks SET Title = @Title, Description = @Description, IsCompleted = @IsCompleted, DueDate = @DueDate, 
                                       UserId = @UserId, CategoryId = @CategoryId, Priority = @Priority WHERE Id = @TaskId";
    public const string UpdateUser = @"UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Password = @Password 
                                       WHERE Id = @UserId";
    public const string UpdateComment = @"UPDATE Comments SET Content = @Content, CreatedAt = @CreatedAt WHERE Id = @CommentId";
    public const string UpdateTaskHistory = @"UPDATE TaskHistory SET ChangeDescription = @ChangeDescription, ChangedAt = @ChangedAt WHERE Id = @TaskHistoryId";
    public const string UpdateTaskAttachment = @"UPDATE TaskAttachments SET FilePath = @FilePath WHERE Id = @TaskAttachmentId";
    #endregion

    #region Deletes
    public const string DeleteCategory = @"DELETE FROM Categories WHERE Id = @CategoryId";
    public const string DeleteTask = @"DELETE FROM Tasks WHERE Id = @TaskId";
    public const string DeleteUser = @"DELETE FROM Users WHERE Id = @UserId";
    public const string DeleteComment = @"DELETE FROM Comments WHERE Id = @CommentId";
    public const string DeleteTaskHistory = @"DELETE FROM TaskHistory WHERE Id = @TaskHistoryId";
    public const string DeleteTaskAttachment = @"DELETE FROM TaskAttachments WHERE Id = @TaskAttachmentId";
    #endregion

    #region GetById
    
            public const string GetCategoryById = @"SELECT * FROM Categories WHERE Id = @CategoryId";

            public const string GetTaskById = @"SELECT * FROM Tasks WHERE Id = @TaskId";
        
            public const string GetUserById = @"SELECT * FROM Users WHERE Id = @UserId";
          
            public const string GetTaskHistoryById = @"SELECT * FROM TaskHistory WHERE TaskId = @TaskId";

            public const string GetCommentsByTaskId = @"SELECT * FROM Comments WHERE TaskId = @TaskId";
            
            public const string GetTaskAttachmentsByTaskId = @"SELECT * FROM TaskAttachments WHERE TaskId = @TaskId";

        #endregion

        
        #region GetAll

            public const string GetAllCategories = @"SELECT * FROM Categories";
            public const string GetAllTasks = @"SELECT * FROM Tasks";
            public const string GetAllUsers = @"SELECT * FROM Users";
            public const string GetAllTaskHistory = @"SELECT * FROM TaskHistory";
            public const string GetAllComments = @"SELECT * FROM Comments";
            public const string GetAllTaskAttachments = @"SELECT * FROM TaskAttachments";
            #endregion
            
            
            public const string selectusersTask =
                "Select u.id,u.username,email,t.id,t.title,t.description,t.priority\nfrom users u \njoin tasks t On t.userid=u.id";

            public const string selectCategoryTaskCount =
                "select c.id,c.name as CategoryName,Count(t.id)As TaskCount\nfrom categories c\nJoin Tasks t on t.categoryid=c.id\nGroup By c.name,c.id";

            public const string selectTasksByPriority = "select* from Tasks where  priority =@Priority";

            public const string selectTaskUsersCategory =
                "select t.id as TaskId,t.title as TaskTitle,t.description as TaskDescription,t.isCompleted,t.dueDate,u.id as UserId,u.username,c.id as CategoryId,c.name as CategoryName,t.priority\nfrom tasks t\njoin  users u on t.userId = u.id\njoin categories c on t.categoryId = c.id;";

            public const string selectTaskOrderByDuedate = "\nselect *\nfrom Tasks\norder by Duedate ;\n";
            public const string selectTaskHistoryOrderByChangedAt = "select * from TaskHistory\nwhere TaskId = @TaskId;";

            public const string selectCommentTaskFiltringUser =
                "select c.content, c.CreatedAt, u.UserName\nfrom comments c\njoin Users u ON c.UserId = u.Id\nwhere c.TaskId = @TaskId\nand c.UserId = @UserId ";

            public const string selectAllTaskAttachmentsTaskUser =
                "select ta.FilePath,ta.CreatedAt,u.UserName,u.Email\nfrom TaskAttachments as ta\njoin tasks as t on ta.taskId = t.id\njoin users as u on t.userId=u.id\nwhere ta.taskId=@TaskId";

            public const string selectTaskFiltringDueDate =
                "SELECT *\nFROM Tasks\nWHERE TO_CHAR(DueDate, 'YYYY-MM-DD') LIKE @DueDate || '%'";
    
            public const string selectAllTaskFiltringIsStatuseAndPriority =
                "SELECT *\nFROM Tasks\nWHERE IsCompleted = @IsCompleted\n  AND Priority = @Priority";


}