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

    public class TaskService : ITask
    {
        public async Task<bool> Create(Tasks task)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(Commands.InsertTask, task) > 0;
            }
        }

        public async Task<Tasks> GetById(Guid id)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.QuerySingleAsync<Tasks>(Commands.GetTaskById, new { id });
            }
        }

        public async Task<bool> Update(Tasks task)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(Commands.UpdateTask, task) > 0;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(Commands.DeleteTask, new { id }) > 0;
            }
        }

        public async Task<IEnumerable<Tasks>> GetAll()
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Tasks>(Commands.GetAllTasks);
            }
        }
    }
}
