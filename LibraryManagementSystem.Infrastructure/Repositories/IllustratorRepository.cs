using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Infrastructure.Repositories;

public class IllustratorRepository : IIllustratorRepository
{
    private readonly ApplicationDbContext _context;

    public IllustratorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Illustrator>> GetAllAsync()
    {
        return await _context.Illustrators.ToListAsync();
    }

    public async Task<Illustrator?> GetByIdAsync(int illustratorId)
    {
        return await _context.Illustrators.FindAsync(illustratorId);
    }
}