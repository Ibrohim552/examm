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

    public class UserService : IUser
    {
        public async Task<bool> CreateAsync(User user)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(Commands.InsertUser, user) > 0;
            }
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.QuerySingleAsync<User>(Commands.GetUserById, new { id });
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(Commands.DeleteUser, new { id }) > 0;
            }
        }

        public async Task<bool> UpdateAsync(User user)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(Commands.UpdateUser, user) > 0;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                 return await conn.QueryAsync<User>(Commands.GetAllUsers);
             
          }
        }
    }
}
