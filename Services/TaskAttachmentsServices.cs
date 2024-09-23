using Classes;
using interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace Services
{
    using Commands;

    public class TaskAttachmentsService : ITaskAttachments
    {
        public async Task<TaskAttachments> GetByIdAsync(Guid id)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.QuerySingleAsync<TaskAttachments>(Commands.GetTaskAttachmentsByTaskId, new { id });
            }
        }

        public async Task<IEnumerable<TaskAttachments>> GetAllAsync()
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<TaskAttachments>(Commands.GetAllTaskAttachments);
            }
        }

        public async Task<bool> CreateAsync(TaskAttachments taskAttachment)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(Commands.InsertTaskAttachment, taskAttachment) > 0;
            }
        }

        public async Task<bool> UpdateAsync(TaskAttachments taskAttachment)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(Commands.UpdateTaskAttachment, taskAttachment) > 0;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(Commands.DeleteTaskAttachment, new { id }) > 0;
            }
        }
    }
}
