using Classes;
namespace interfaces;

 public interface ITaskAttachments
    {
        Task<TaskAttachments> GetByIdAsync(Guid id);
        Task<IEnumerable<TaskAttachments>> GetAllAsync();
        Task<bool> CreateAsync(TaskAttachments taskAttachment);
        Task<bool> UpdateAsync(TaskAttachments taskAttachment);
        Task<bool> DeleteAsync(Guid id);
    }