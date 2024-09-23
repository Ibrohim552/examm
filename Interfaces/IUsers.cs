using Classes;
namespace interfaces;

 public interface IUser
    {
        Task<bool> CreateAsync(User user);
        Task<User> GetByIdAsync(Guid id);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }