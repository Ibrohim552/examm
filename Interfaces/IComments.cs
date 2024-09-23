namespace interfaces;

using Classes;


    public interface IComments
    {
        Task<bool> CreateCommentAsync(Comments comments);
        Task<bool> UpdateCommentAsync(Comments comments);
        Task<bool> DeleteCommentAsync(Guid id);
        Task<Comments> GetCommentByIdAsync(Guid id);
        Task<IEnumerable<Comments>> GetAllComments();
    }

