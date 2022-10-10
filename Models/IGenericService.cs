namespace Blooopy.Models;

public interface IGenericService<T> where T : class
{
    Task<List<T>?> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<int> SaveAsync(T item);
    Task<int> DeleteAsync(T item);
}