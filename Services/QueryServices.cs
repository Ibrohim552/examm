using Classes;
using Dapper;
using  selectdtos;
using Npgsql;


namespace Services;

public class QueryServices
{
    public async Task<IEnumerable<UserWithTasks>> SelectUserTasksAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Commands.Commands.connectionstring))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<UserWithTasks>(Commands.Commands.selectusersTask);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<CategoryWithTaskCount>> SelectCategoryTasksCountAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Commands.Commands.connectionstring))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<CategoryWithTaskCount>(Commands.Commands.selectCategoryTaskCount);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<TaskByPriority>> SelectTasksByPriority(string priority)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Commands.Commands.connectionstring))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<TaskByPriority>(Commands.Commands.selectTasksByPriority,new {Priority=priority});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<TaskWithUserAndCategory>> SelectTasksUsersCategoriesAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Commands.Commands.connectionstring))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<TaskWithUserAndCategory>(Commands.Commands.selectTaskUsersCategory);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<TaskSortedByDueDate>> SelectTasksOrderByDueDateAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Commands.Commands.connectionstring))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<TaskSortedByDueDate>(Commands.Commands.selectTaskOrderByDuedate);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<TaskHistoryById>> SelectTaskHistroyByTaskIdAsync(Guid taskId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Commands.Commands.connectionstring))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<TaskHistoryById>(Commands.Commands.selectTaskHistoryOrderByChangedAt, new {TaskId=taskId});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<CommentsByTaskAndUser>> SelectCommentTaskFilteringUserAsync(Guid taskId, Guid userId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Commands.Commands.connectionstring))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<CommentsByTaskAndUser>(Commands.Commands.selectCommentTaskFiltringUser, new {TaskId=taskId, UserId=userId});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<TaskAttachmentWithUserInfo>> SelectTaskAttachmentsUserAsync(Guid taskId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Commands.Commands.connectionstring))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<TaskAttachmentWithUserInfo>(Commands.Commands.selectAllTaskAttachmentsTaskUser, new {TaskId=taskId});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<TaskByDueDateRange>> selectTaskFiltringDueDateAsync(string date)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Commands.Commands.connectionstring))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<TaskByDueDateRange>(Commands.Commands.selectTaskFiltringDueDate, new {DueDate=date});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<TaskByStatusAndPriority>> SelectAllTaskFiltringIsStatuseAndPriorityAsync(bool iscomplated, string priority)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Commands.Commands.connectionstring))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<TaskByStatusAndPriority>(Commands.Commands.selectAllTaskFiltringIsStatuseAndPriority, new {IsCompleted=iscomplated, Priority=priority});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}