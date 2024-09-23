using Classes;
using interfaces;
using Dapper;
using Npgsql;

namespace Services
{
    using Commands;

    public class TaskHistoryService : ITaskHistory
    {
        public async Task<bool> CreateAsync(TaskHistories taskHistories)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(Commands.InsertTaskHistory, taskHistories) > 0;
            }
        }

        public async Task<bool> UpdateAsync(TaskHistories taskHistories)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(Commands.UpdateTaskHistory, taskHistories) > 0;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(Commands.DeleteTaskHistory, new { id }) > 0;
            }
        }

        public async Task<TaskHistories> GetByIdAsync(Guid id)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.QuerySingleAsync<TaskHistories>(Commands.GetTaskHistoryById, new { id });
            }
        }

        public async Task<IEnumerable<TaskHistories>> GetAllAsync()
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<TaskHistories>(Commands.GetAllTaskHistory);
            }
        }
    }
}
