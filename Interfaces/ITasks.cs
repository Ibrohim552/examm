using Classes;
namespace interfaces;

public interface ITask
{
    Task<bool> Create(Tasks task);
    Task<Tasks> GetById(Guid id);
    Task<bool> Update(Tasks task);
    Task<bool> Delete(Guid id);
    Task<IEnumerable<Tasks>> GetAll();

}