namespace interfaces;
using Classes;

 public interface ITaskHistory
    {
        Task<bool> CreateAsync(TaskHistories taskHistories);
        Task<bool> UpdateAsync(TaskHistories taskHistories);
        Task<bool> DeleteAsync(Guid id);
        Task<TaskHistories> GetByIdAsync(Guid id);
        Task<IEnumerable<TaskHistories>> GetAllAsync();
    }