namespace LibraryManagementSystem.Application.Interfaces;

public interface IIllustratorRepository
{
    Task<IEnumerable<Illustrator>> GetAllAsync();
    Task<Illustrator?> GetByIdAsync(int illustratorId);  
}