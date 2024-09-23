namespace interfaces;

using Classes;

public interface ICagetories
{
     Task<bool>  CreateCategoryAsync(Categories categories);
    Task<bool> UpdateCategoryAsync(Categories categories);
    Task<bool> DeleteCategoryAsync(Guid id);
     Task<Categories> GetByIdAsync(Guid id);
   Task<IEnumerable<Categories>> GetAllCategoriesAsync();
}