using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly ApplicationDbContext _context;

    public AuthorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return await _context.Authors.ToListAsync();
    }

    public async Task<Author?> GetByIdAsync(int authorId)
    {
        return await _context.Authors.FindAsync(authorId);
    }
}