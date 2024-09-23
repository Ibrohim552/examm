using Classes;
using interfaces;
using Dapper;
using Npgsql;

namespace Services
{
    using Commands;

    public class CommentsService : IComments
    {
        public async Task<bool> CreateCommentAsync(Comments comments)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(Commands.InsertComment, comments) > 0;
            }
        }

        public async Task<bool> UpdateCommentAsync(Comments comments)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(Commands.UpdateComment, comments) > 0;
            }
        }

        public async Task<bool> DeleteCommentAsync(Guid id)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(Commands.DeleteComment, new { id }) > 0;
            }
        }

        public async Task<Comments> GetCommentByIdAsync(Guid id)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.QuerySingleAsync<Comments>(Commands.GetCommentsByTaskId, new { id });
            }
        }

        public async Task<IEnumerable<Comments>> GetAllComments()
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return  await conn.QueryAsync<Comments>(Commands.GetAllComments);
            }
        }
    }
}
