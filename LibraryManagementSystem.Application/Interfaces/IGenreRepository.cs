namespace LibraryManagementSystem.Application.Interfaces;

public interface IGenreRepository
{
    Task<IEnumerable<Genre>> GetAllAsync();
    Task<Genre?> GetByIdAsync(int genreId); 
}