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

    public class CategoryServices : ICagetories
    {
        public async Task<bool> CreateCategoryAsync(Categories categories)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(Commands.InsertCategory, categories) > 0;
            }
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(Commands.DeleteCategory, new { id }) > 0;
            }
        }

        public async Task<IEnumerable<Categories>> GetAllCategoriesAsync()
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Categories>(Commands.GetAllCategories);
            }
        }

        public async Task<Categories> GetByIdAsync(Guid id)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.QuerySingleAsync<Categories>(Commands.GetCategoryById, new { id });
            }
        }

        public async Task<bool> UpdateCategoryAsync(Categories categories)
        {
            using (var conn = new NpgsqlConnection(Commands.connectionstring))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(Commands.UpdateCategory, categories) > 0;
            }
        }
    }
}
