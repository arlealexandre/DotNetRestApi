namespace LibraryManagementSystem.Application.Interfaces;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAsync();
    Task<Author?> GetByIdAsync(int authorId);  
}